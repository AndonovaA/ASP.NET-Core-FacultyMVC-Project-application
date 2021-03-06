﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyMVC.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Degree { get; set; }

        [StringLength(25)]
        public string AcademicRank { get; set; }

        [StringLength(10)]
        public string OfficeNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        public string ProfilePicture { get; set; }

        public string FullName {
            //get { return string.Format("{0}, {1}", FirstName, LastName);}
            get { return FirstName + " " + LastName; }
            
        }

        public ICollection<Course> Courses_first { get; set; }

        public ICollection<Course> Courses_second { get; set; }
    }
}
