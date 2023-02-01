using Database.Database;
using IRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.NewFolder;
using Repository.Base;
using EntityFrameworkCore.RawSQLExtensions.Extensions;

namespace Repository.Repository
{
    public class StudentRepository : Repository<StudentInfo>, IStudentInfoRepository
    {
        ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<ICollection<StudentDetailsVM>> GetByCode(string code)
        {

            return await _db.Database.SqlQuery<StudentDetailsVM>($"Exec GetDetailsByCode {code}").ToListAsync();
        }
    }
}
