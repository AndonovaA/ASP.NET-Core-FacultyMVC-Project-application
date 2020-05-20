using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacultyMVC.Data;
using FacultyMVC.Models;
using FacultyMVC.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FacultyMVC.Controllers
{
    
    public class EnrollmentsController : Controller
    {
        private readonly FacultyMVCContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private UserManager<AppUser> userManager;

        public EnrollmentsController(FacultyMVCContext context, IWebHostEnvironment webHostEnvironment, UserManager<AppUser> userMan)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            userManager = userMan;
        }

        // GET: Enrollments
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string enrollmentCourse, int enrollmentYear, string enrollmentSemester) 
        {
            IQueryable<Enrollment> enrollments = _context.Enrollment.AsQueryable();
            IQueryable<int> yearQuery = _context.Enrollment.OrderBy(m => m.Year).Select(m => m.Year).Distinct(); 
            IQueryable<string> semesterQuery = _context.Enrollment.Where(m => m.Semester != null).OrderBy(m => m.Semester).Select(m => m.Semester).Distinct(); //ama ne mi gi zema distinct

            if (!string.IsNullOrEmpty(enrollmentCourse))
            {
                enrollments = enrollments.Where(s => s.Course.Title.ToLower().Contains(enrollmentCourse.ToLower()));
            }
            if (enrollmentYear != 0)
            {
                enrollments = enrollments.Where(x => x.Year == enrollmentYear);
            }
            if (!string.IsNullOrEmpty(enrollmentSemester))
            {
                enrollments = enrollments.Where(s => s.Semester.Equals(enrollmentSemester) );
            }

            var vm = new EnrollmentFilterViewModel
            {
                Years = new SelectList(await yearQuery.ToListAsync()), 
                Semesters = new SelectList(await semesterQuery.ToListAsync()),
                Enrollments = await enrollments.OrderBy(e=>e.Course.Title).Include(s => s.Course).Include(s=>s.Student).ToListAsync()
            };
            return View(vm); 
        }

        // GET: Enrollments/CourseStudents/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> CourseStudents(int? id, int enrollmentYear)
        {
            if (id == null)
            {
                return NotFound();
            }

            IQueryable<Enrollment> enrollments = _context.Enrollment.Where(e => e.CourseId == id);
            enrollments = enrollments.Include(e => e.Course).Include(e => e.Student).OrderBy(e=>e.Student.Index).OrderBy(e=>e.Student.Index);
            
            if(enrollments != null)
            {
                var anyenrollment = enrollments.First();
                AppUser loggedUser = await userManager.GetUserAsync(User);
                if ((loggedUser.TeacherId != anyenrollment.Course.FirstTeacherId) && (loggedUser.TeacherId != anyenrollment.Course.SecondTeacherId))
                {
                    return RedirectToAction("AccessDenied", "Account", null);
                }
            }

            if (enrollmentYear != 0)
            {
                enrollments = enrollments.Where(x => x.Year == enrollmentYear);
            }
            else
            {
                //po default se prikazuvat studentite zapisani vo poslednata godina
                enrollments = enrollments.Where(x => x.Year == DateTime.Now.Year);
            }

            EnrollmentFilterViewModel vm = new EnrollmentFilterViewModel
            {
                Enrollments = await enrollments.ToListAsync()
            };

            ViewData["CourseName"] = _context.Course.Where(c => c.Id == id).Select(c => c.Title).FirstOrDefault();
            return View(vm);
        }

        // GET: Enrollments/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Semester,Year,Grade,SeminalUrl,ProjectUrl,ExamPoints,SeminalPoints,ProjectPoints,AdditionalPoints,FinishDate,CourseId,StudentId")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5 
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Enrollment enrollment = await _context.Enrollment.Include(e => e.Course).Where(e => e.Id == id).FirstOrDefaultAsync();
            if (enrollment == null)
            {
                return NotFound();
            }
           

            AppUser loggedUser = await userManager.GetUserAsync(User);
            if ((loggedUser.TeacherId != enrollment.Course.FirstTeacherId) && (loggedUser.TeacherId != enrollment.Course.SecondTeacherId))
            {
                return RedirectToAction("AccessDenied", "Account", null);
            }

            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FullName", enrollment.StudentId);
            ViewData["StudentName"] = _context.Student.Where(s => s.Id == enrollment.StudentId).Select(s => s.FullName).FirstOrDefault();
            ViewData["CourseName"] = _context.Course.Where(s => s.Id == enrollment.CourseId).Select(s => s.Title).FirstOrDefault();
            return View(enrollment);
        }

        // GET: Enrollments/EditByAdmin/5 
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditByAdmin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FullName", enrollment.StudentId);
            ViewData["StudentName"] = _context.Student.Where(s => s.Id == enrollment.StudentId).Select(s => s.FullName).FirstOrDefault();
            ViewData["CourseName"] = _context.Course.Where(s => s.Id == enrollment.CourseId).Select(s => s.Title).FirstOrDefault();
            return View(enrollment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<IActionResult> Edit(int id, string pom, [Bind("Id,Semester,Year,Grade,SeminalUrl,ProjectUrl,ExamPoints,SeminalPoints,ProjectPoints,AdditionalPoints,FinishDate,CourseId,StudentId")] Enrollment enrollment)
        {
            if (id != enrollment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (pom.Equals("admin"))
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("CourseStudents", new { id = enrollment.CourseId });
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FullName", enrollment.StudentId);

            if (pom.Equals("admin"))
            {
                return View("EditByAdmin", enrollment);
            }
            else {
                return View(enrollment); }
        }

        // GET: Enrollments/Details/5
        [Authorize(Roles = "Student")] 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (enrollment == null)
            {
                return NotFound();
            }

            AppUser loggedUser = await userManager.GetUserAsync(User);
            if (loggedUser.StudentId != enrollment.StudentId)
            {
                return RedirectToAction("AccessDenied", "Account", null);
            }

            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollment.FindAsync(id);
            _context.Enrollment.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        // GET: Enrollments/EditByStudent/5
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> EditByStudent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            } 

            var enrollment = await _context.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            AppUser loggedUser = await userManager.GetUserAsync(User);
            if (loggedUser.StudentId != enrollment.StudentId)
            {
                return RedirectToAction("AccessDenied", "Account", null);
            }

            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FullName", enrollment.StudentId);

            EnrollmentFormViewModel vm = new EnrollmentFormViewModel
            {
                Id = enrollment.Id,
                Semester = enrollment.Semester,
                Year = enrollment.Year,
                Grade = enrollment.Grade,
                ProjectUrl = enrollment.ProjectUrl,
                SeminalPoints = enrollment.SeminalPoints,
                ProjectPoints = enrollment.ProjectPoints,
                AdditionalPoints = enrollment.AdditionalPoints,
                ExamPoints = enrollment.ExamPoints,
                FinishDate = enrollment.FinishDate,
                CourseId = enrollment.CourseId,
                StudentId = enrollment.StudentId
            };

            ViewData["StudentName"] = _context.Student.Where(s => s.Id == enrollment.StudentId).Select(s => s.FullName).FirstOrDefault();
            ViewData["CourseName"] = _context.Course.Where(s => s.Id == enrollment.CourseId).Select(s => s.Title).FirstOrDefault();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> EditByStudent(int id, EnrollmentFormViewModel vm)
        { 
            if (id != vm.Id) 
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = UploadedFile(vm);

                    Enrollment enrollment= new Enrollment
                    {
                        Id=vm.Id,
                        Semester= vm.Semester,
                        Year= vm.Year,
                        Grade= vm.Grade,
                        SeminalUrl = uniqueFileName,
                        ProjectUrl = vm.ProjectUrl,
                        SeminalPoints=vm.SeminalPoints,
                        ProjectPoints=vm.ProjectPoints,
                        AdditionalPoints=vm.AdditionalPoints,
                        ExamPoints=vm.ExamPoints,
                        FinishDate=vm.FinishDate,
                        CourseId=vm.CourseId,
                        StudentId=vm.StudentId
                    };

                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(vm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = vm.Id });
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", vm.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FullName", vm.StudentId);
            return View(vm);
        }

        private string UploadedFile(EnrollmentFormViewModel model)
        {
            string uniqueFileName = null;

            if (model.SeminalUrl != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "seminalFiles");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.SeminalUrl.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.SeminalUrl.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public ActionResult DownloadFile(string filename)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "seminalFiles");
            string filePath = Path.Combine(uploadsFolder, filename);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.Id == id);
        }
    }
}
