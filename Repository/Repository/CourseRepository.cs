using Database.Database;
using IRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        ApplicationDbContext _db;
        public CourseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<ICollection<Course>> GetAllCourseByDepartment(int id)
        {
            return await _db.Courses.Where(p => p.DepartmentId == id).ToListAsync();
        }
    }
}
