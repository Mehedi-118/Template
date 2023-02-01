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
    public class GenericLookupTypeService : Service<GenericLookupType>, IGenericLookupTypeService
    {
        private readonly IGenericLookupTypeRepository _genericLookupTypeRepository;

        public GenericLookupTypeService(IGenericLookupTypeRepository genericLookupTypeRepository) : base(genericLookupTypeRepository)
        {
            _genericLookupTypeRepository = genericLookupTypeRepository;
        }

    }
}
