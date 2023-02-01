using IRepository.Base;
using IService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Service.Base
{
    public abstract class Service<T> : IGenericService<T> where T : class
    {
        protected IGenericRepository<T> _genericRepository;

        public Service(IGenericRepository<T> genericRepository)
        {
            _genericRepository=genericRepository;
        }
        public virtual bool CreateAsync(T entity)
        {
            var isSuccess=_genericRepository.CreateAsync(entity);
            if(isSuccess)
            {
                return true;
            }
            return false;
        }

        public bool DeleteAsync(T entity)
        {
            var isSuccess=_genericRepository.DeleteAsync(entity);
            if(isSuccess) { return true; }
            return false;
        }

        public Task<ICollection<T?>> GetAllAsync()
        {
            return _genericRepository.GetAllAsync();
        }

        public Task<T?> GetByIdAsync(int id)
        {
            return _genericRepository.GetByIdAsync(id);
        }

        public bool UpdateAsync(T entity)
        {
            var isSuccess= _genericRepository.UpdateAsync(entity);
            if(isSuccess) { return true; }
            return false;
        }
    }
}
