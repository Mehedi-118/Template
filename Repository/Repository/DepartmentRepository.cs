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
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
