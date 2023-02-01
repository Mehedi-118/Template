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
    public class CourseService : Service<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository) : base(courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task<ICollection<Course>> GetAllCourseByDepartment(int id)
        {
            return _courseRepository.GetAllCourseByDepartment(id);
        }
    }

}
