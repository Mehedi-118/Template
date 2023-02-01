using IRepository.Base;
using Model;
using Model.NewFolder;

namespace IRepository.Repositories
{
    public interface IStudentInfoRepository : IGenericRepository<StudentInfo>
    {
        Task<ICollection<StudentDetailsVM>> GetByCode(string code);
    }
}
