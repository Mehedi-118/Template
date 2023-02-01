using IService.Base;
using Model;
using Model.NewFolder;

namespace IService.Services
{
    public interface IStudentService : IGenericService<StudentInfo>
    {
        Task<ICollection<StudentDetailsVM>> GetByCode(string code);
    }
}
