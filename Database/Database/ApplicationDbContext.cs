using Database.Seed;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<StudentInfo> Students { get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<StudentCourses> StudentsCourses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<GenericLookup> GenericLookup { get; set; }
        public DbSet<GenericLookupType> GenericLookupType { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            modelBuilder.Entity<StudentCourses>()
                .HasOne(p => p.StudentInfo)
                .WithMany(q => q.StudentCourses)
                .HasForeignKey(r=>r.StudentInfoId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
