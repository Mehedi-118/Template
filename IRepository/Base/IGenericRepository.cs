using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Base
{
    public interface IGenericRepository<T> where T : class
    {
        bool  CreateAsync(T entity);
        bool  UpdateAsync(T entity);
        bool  DeleteAsync(T entity);
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
