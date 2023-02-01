using Database.Database;
using IRepository.Base;
using Microsoft.EntityFrameworkCore;

namespace Repository.Base
{
    public abstract class Repository<T> : IGenericRepository<T> where T : class
    {
        ApplicationDbContext _db;

        public DbSet<T> Table
        {
            get
            {
                return _db.Set<T>();
            }
        }

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }
        public virtual bool CreateAsync(T entity)
        {
            Table.AddAsync(entity);
            var isSuccess = _db.SaveChanges();
            if (isSuccess > 0)
                return true;
            return false;

        }

        public virtual bool DeleteAsync(T entity)
        {
            Table.Remove(entity);
            var isSuccess = _db.SaveChanges();
            if (isSuccess > 0)
                return true;
            return false;
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            var data = await Table.ToListAsync();
            if (data.Count > 0 || data != null)
            {
                return data;
            }
            return null;
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            var data = await Table.FindAsync(id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public bool UpdateAsync(T entity)
        {
            Table.Update(entity);
            var isSuccess = _db.SaveChanges();
            if (isSuccess > 0)
                return true;
            return false;
        }
    }
}