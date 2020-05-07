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

namespace FacultyMVC.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly FacultyMVCContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EnrollmentsController(FacultyMVCContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var facultyMVCContext = _context.Enrollment.Include(e => e.Course).Include(e => e.Student).OrderBy(e=>e.Course.Title);
            return View(await facultyMVCContext.ToListAsync());
        }

        // GET: Enrollments/CourseStudents/5
        public async Task<IActionResult> CourseStudents(int? id, int enrollmentYear)
        { 
            if (id == null)
            {
                return NotFound();
            }

            IQueryable<Enrollment> enrollments = _context.Enrollment.Where(e => e.CourseId == id);
            enrollments = enrollments.Include(e => e.Course).Include(e => e.Student).OrderBy(e=>e.Student.Index).OrderBy(e=>e.Student.Index);

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
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FirstName");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Semester,Year,Grade,SeminalUrl,ProjectUrl,ExamPoints,SeminalPoints,ProjectPoints,AdditionalPoints,FinishDate,CourseId,StudentId")] Enrollment enrollment)
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
                return RedirectToAction("CourseStudents", new { id = enrollment.CourseId });
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FullName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollments/Details/5
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

            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollment.FindAsync(id);
            _context.Enrollment.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Enrollments/EditByStudent/5
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

        // POST: Enrollments/EditByStudent/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
