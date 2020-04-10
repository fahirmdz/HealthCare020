using AutoMapper;
using HealthCare020.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HealthCare020.Services
{
    public class BaseService<TModel, TSearch, TEntity> : IService<TEntity, TModel, TSearch> where TEntity : class
    {
        protected readonly HealthCare020DbContext _dbContext;
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper, HealthCare020DbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public virtual async Task<IList<TModel>> Get(TSearch search)
        {
            var result =await _dbContext.Set<TEntity>().ToListAsync();

            if (result.Any())
                return _mapper.Map<List<TModel>>(result);
            return new List<TModel>();
        }

        public virtual async Task<IList<TModel>> GetWithEagerLoad(TSearch search)
        {
           return new List<TModel>();
        }

        public async Task<TModel> GetById(int id)
        {
            var result = await _dbContext.Set<TEntity>().FindAsync(id);
            if(result==null)
                throw new NotFoundException("Not Found");
            return _mapper.Map<TModel>(result);
        }

        public virtual async Task<TModel> FindWithEagerLoad(int id)
        {
            throw new NotImplementedException();
        }
    }
}