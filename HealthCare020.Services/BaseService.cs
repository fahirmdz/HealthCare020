using AutoMapper;
using HealthCare020.Repository.Interfaces;
using HealthCare020.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class BaseService<TModel, TSearch, TEntity> : IService<TEntity, TModel, TSearch> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected string[] children;
        public Expression<Func<TEntity, bool>> filterForId;


        public BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int TempId { get; set; }

        public Expression<Func<TEntity, bool>> GetFilterForId()
        {
            return filterForId;
        }

        public async Task<IList<TModel>> Get(TSearch search)
        {
            var result = await _unitOfWork.Set<TEntity>().GetAll();
            if (result != null)
                return _mapper.Map<List<TModel>>(result);
            return null;
        }

        public async Task<IList<TModel>> GetWithEagerLoad(TSearch search)
        {
            var result = children != null && children.Any() ? await _unitOfWork.Set<TEntity>().GetAllWithEagerLoad(children) : await _unitOfWork.Set<TEntity>().GetAll();
            if (result != null)
                return _mapper.Map<List<TModel>>(result);
            return null;
        }

        public async Task<TModel> GetById(int id)
        {
            var result = await _unitOfWork.Set<TEntity>().GetById(id);
            return _mapper.Map<TModel>(result);
        }

        public async Task<TModel> FindWithEagerLoad(Expression<Func<TEntity, bool>> filter)
        {
            var result = await _unitOfWork.Set<TEntity>().FindWithEagerLoad(filter, children);
            return _mapper.Map<TModel>(result);
        }
    }
}