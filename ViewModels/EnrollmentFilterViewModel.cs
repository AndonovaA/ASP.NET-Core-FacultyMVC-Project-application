using FacultyMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyMVC.ViewModels
{
    public class EnrollmentFilterViewModel
    {
        public IList<Enrollment> Enrollments { get; set; }

        public string EnrollmentCourse { get; set; }
        public int EnrollmentYear { get; set; }
        public SelectList Years { get; set; } 
        public string EnrollmentSemester { get; set; }
        public SelectList Semesters { get; set; } 
    }
}
