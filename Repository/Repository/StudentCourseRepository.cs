using Database.Database;
using IRepository.Repositories;
using Model;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class StudentCourseRepository : Repository<StudentCourses>, IStudentCourseRepository
    {
        ApplicationDbContext _db;
        public StudentCourseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

       
    }
}
