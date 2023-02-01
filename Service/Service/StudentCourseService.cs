using IRepository.Repositories;
using IService.Services;
using Model;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class StudentCourseService : Service<StudentCourses>, IStudentCourseService
    {
        private readonly IStudentCourseRepository _studentCourseRepository;

        public StudentCourseService(IStudentCourseRepository studentCourseRepository) : base(studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
        }

    }
}
