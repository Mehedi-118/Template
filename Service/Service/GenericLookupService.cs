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
    public class GenericLookupService : Service<GenericLookup>, IGenericLookupService
    {
        private readonly IGenericLookupRepository _genericLookupRepository;

        public GenericLookupService(IGenericLookupRepository genericLookupRepository) : base(genericLookupRepository)
        {
            _genericLookupRepository = genericLookupRepository;
        }

    }
}
