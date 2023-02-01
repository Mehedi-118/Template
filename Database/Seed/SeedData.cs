using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Seed
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GenericLookupType>().HasData(
                new GenericLookupType { Id = 1, Name = "ResultType" }
            );
            modelBuilder.Entity<GenericLookup>().HasData(
              new GenericLookup { Id = 1, Grade = "3.25", GenericLookupTypeId = 1 },
              new GenericLookup { Id = 2, Grade = "3.50", GenericLookupTypeId = 1 },
              new GenericLookup { Id = 3, Grade = "3.75", GenericLookupTypeId = 1 },
              new GenericLookup { Id = 4, Grade = "3.86", GenericLookupTypeId = 1 },
              new GenericLookup { Id = 5, Grade = "4.00", GenericLookupTypeId = 1 }
            );
            modelBuilder.Entity<Department>().HasData(
              new Department { Id = 1, Name = "EEE" },
              new Department { Id = 2, Name = "CSE" },
              new Department { Id = 3, Name = "ME" },
              new Department { Id = 4, Name = "TE" },
              new Department { Id = 5, Name = "ECE" }

            );
            modelBuilder.Entity<StudentInfo>().HasData(
              new StudentInfo { Id = 1, Name = "Iron Man", DepartmentId = 2, Code = "I01" },
              new StudentInfo { Id = 2, Name = "Hulk", DepartmentId = 2, Code = "H02" },
              new StudentInfo { Id = 3, Name = "Thor", DepartmentId = 1, Code = "T03" },
              new StudentInfo { Id = 4, Name = "Hitman", DepartmentId = 1, Code = "HM01" },
              new StudentInfo { Id = 5, Name = "Black Widow", DepartmentId = 4, Code = "B05" }

            );
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Algorithm", Description = "", DepartmentId = 2 },
                new Course { Id = 2, Name = "Data Structure", Description = "", DepartmentId = 2 },
                new Course { Id = 3, Name = "OOP", Description = "", DepartmentId = 2 },

                new Course { Id = 4, Name = "Circuit Analysis", Description = "", DepartmentId = 1 },
                new Course { Id = 5, Name = "Load Balancing", Description = "", DepartmentId = 1 },
                new Course { Id = 6, Name = "Circuit Desing", Description = "", DepartmentId = 1 }

            );

            modelBuilder.Entity<StudentCourses>().HasData(
                new StudentCourses { Id = 1, StudentInfoId = 1, CourseId = 1, GradeId = 5 },
                new StudentCourses { Id = 2, StudentInfoId = 1, CourseId = 2, GradeId = 4 },

                new StudentCourses { Id = 3, StudentInfoId = 2, CourseId = 2, GradeId = 2 },
                new StudentCourses { Id = 4, StudentInfoId = 2, CourseId = 3, GradeId = 3 },

                new StudentCourses { Id = 5, StudentInfoId = 3, CourseId = 4, GradeId = 2 },
                new StudentCourses { Id = 6, StudentInfoId = 3, CourseId = 5, GradeId = 5 }


                );

        }


    }
}
