using FacultyMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyMVC.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FacultyMVCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FacultyMVCContext>>()))
            {
                if (context.Course.Any() || context.Enrollment.Any() || context.Student.Any() || context.Teacher.Any())
                {
                    return;
                }

                context.Course.AddRange(
                new Course { Title = "PIA", Credits = 6, Semester = 1, FirstTeacherId = 1, SecondTeacherId = 2},
                new Course { Title = "RSWEB", Credits = 6, Semester = 6, Programme= "KTI", FirstTeacherId = 3, SecondTeacherId = 4 },
                new Course { Title = "MPB", Credits = 6, Semester = 4, Programme = "TKII", FirstTeacherId = 5, SecondTeacherId = 6 }
                );
                context.SaveChanges();

                context.Teacher.AddRange(
                new Teacher { FirstName = "Marija", LastName = "Petkovska" , Degree= "Dr", AcademicRank= "Docent", ProfilePicture= "f521037e-5d54-48d6-9d8d-fcc51b8e9ee8_FB_IMG_1482497638726.jpg"},
                new Teacher { FirstName = "Trajko", LastName = "Trajkovski", Degree = "Dr", AcademicRank = "Professor" },
                new Teacher { FirstName = "Sofija", LastName = "Sekulova", Degree = "Dr", AcademicRank = "Docent" },
                new Teacher { FirstName = "Jana", LastName = "Sanova", Degree = "PhD", AcademicRank = "Assistant" },
                new Teacher { FirstName = "Billy", LastName = "Crystal", Degree = "Dr", AcademicRank = "Academic" },
                new Teacher { FirstName = "Patricia", LastName = "Montila", Degree = "PhD", AcademicRank = "Assistant", ProfilePicture= "d13cd6a3b2bf_IMG_20190102_210853_274.jpg" }
                );
                context.SaveChanges();

                context.Student.AddRange(
                new Student{Index = "173/2017",FirstName = "Anastasija",LastName = "Andonova", AcquiredCredits= 120, CurrentSemestar= 6 , ProfilePicture= "77bafe7d-bc47-419e-8d0d-be1a21e427b1_FB_IMG_1482497610926.jpg"},
                new Student { Index = "111/2017", FirstName = "Simona", LastName = "Simonovijk", AcquiredCredits = 120, CurrentSemestar = 6},
                new Student { Index = "10/2017", FirstName = "Marija", LastName = "Kostovska", AcquiredCredits = 120, CurrentSemestar = 6 },
                new Student { Index = "22/2017", FirstName = "Trajanka", LastName = "Popova", AcquiredCredits = 120, CurrentSemestar = 6 },
                new Student { Index = "201/2018", FirstName = "Marko", LastName = "Markovski", AcquiredCredits = 60, CurrentSemestar = 4 },
                new Student { Index = "44/2018", FirstName = "Stefan", LastName = "Simevski", AcquiredCredits = 60, CurrentSemestar = 4 }
                );
                context.SaveChanges(); 

                context.Enrollment.AddRange(
                    new Enrollment { CourseId = 1, StudentId = 5},
                    new Enrollment { CourseId = 1, StudentId = 6},
                    new Enrollment { CourseId = 2, StudentId = 1},
                    new Enrollment { CourseId = 2, StudentId = 2},
                    new Enrollment { CourseId = 2, StudentId = 3},
                    new Enrollment { CourseId = 3, StudentId = 3},
                    new Enrollment { CourseId = 3, StudentId = 4}
                );
                context.SaveChanges();
            }
        }

    }
}
