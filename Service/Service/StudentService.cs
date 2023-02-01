using IRepository.Repositories;
using IService.Services;
using Model;
using Model.NewFolder;
using Service.Base;

namespace Egen.Service.Services.Student
{
    public class StudentService: Service<StudentInfo>,IStudentService
    {
        private readonly IStudentInfoRepository _studentInfoRepository;

        public StudentService(IStudentInfoRepository studentInfoRepository) : base(studentInfoRepository)
        {
            _studentInfoRepository = studentInfoRepository;
        }

        public Task<ICollection<StudentDetailsVM>> GetByCode(string code)
        {
            return _studentInfoRepository.GetByCode(code);
        }
    }
}
