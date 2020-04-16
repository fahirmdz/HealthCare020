using AutoMapper;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCare020.Core.ResourceParameters;

namespace HealthCare020.Services
{
    public class BaseService<TDto, TResourceParameters, TEntity> : IService<TEntity, TDto, TResourceParameters> where TEntity : class where  TResourceParameters: BaseResourceParameters
    {
        protected readonly HealthCare020DbContext _dbContext;
        protected readonly IMapper _mapper;
        private readonly IPropertyMappingService _propertyMappingService;
        private readonly IPropertyCheckerService _propertyCheckerService;

        public BaseService(IMapper mapper, HealthCare020DbContext dbContext, IPropertyMappingService propertyMappingService, IPropertyCheckerService propertyCheckerService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _propertyMappingService = propertyMappingService;
            _propertyCheckerService = propertyCheckerService;
        }

        public virtual async Task<IList<TDto>> Get(TResourceParameters resourceParameters)
        {
            if (!_propertyCheckerService.TypeHasProperties<TDto>(resourceParameters.Fields))
            {
                throw new UserException($"One or more properties are invalid");
            }

            if (!_propertyMappingService.ValidMappingExistsFor<TDto, TEntity>(resourceParameters.Fields))
            {
                throw new UserException(string.Empty);
            }


            var result = await _dbContext.Set<TEntity>().ToListAsync();

            if (result.Any())
                return _mapper.Map<List<TDto>>(result);
            return new List<TDto>();
        }

        public virtual async Task<IList<TDto>> GetWithEagerLoad(TResourceParameters resourceParameters)
        {
            return new List<TDto>();
        }

        public async Task<TDto> GetById(int id)
        {
            var result = await _dbContext.Set<TEntity>().FindAsync(id);
            if (result == null)
                throw new NotFoundException("Not Found");
            return _mapper.Map<TDto>(result);
        }

        public virtual async Task<TDto> FindWithEagerLoad(int id)
        {
            throw new NotImplementedException();
        }
    }
}