using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthCare020.Repository;
using HealthCare020.Repository.Interfaces;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.Services
{
    public class BaseService<TModel, TSearch, TEntity> : IService<TModel,TSearch> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<TModel>> Get(TSearch search)
        {
            var result = await _unitOfWork.Set<TEntity>().GetAll();

            return _mapper.Map<List<TModel>>(result);
        }

        public async Task<TModel> GetById(int id)
        {
            var result = await _unitOfWork.Set<TEntity>().GetById(id);

            return _mapper.Map<TModel>(result);
        }
    }
}