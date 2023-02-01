using IRepository.Base;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Repositories
{
    public interface ICourseRepository: IGenericRepository<Course>
    {
        Task<ICollection<Course>> GetAllCourseByDepartment(int id);
    }
   
}
