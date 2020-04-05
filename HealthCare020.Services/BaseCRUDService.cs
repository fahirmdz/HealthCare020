using AutoMapper;
using HealthCare020.Repository.Interfaces;
using HealthCare020.Services.Interfaces;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class BaseCRUDService<TModel, TSearch, TEntity, TInsert, TUpdate> : BaseService<TModel, TSearch, TEntity>, ICRUDService<TModel, TSearch, TInsert, TUpdate> where TEntity : class
    {
        public BaseCRUDService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<TModel> Insert(TInsert request)
        {
            var entity = _mapper.Map<TEntity>(request);

            await _unitOfWork.Set<TEntity>().Insert(entity);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entity = _mapper.Map<TEntity>(request);

            _unitOfWork.Set<TEntity>().Update(entity);
            _unitOfWork.Complete();

            return _mapper.Map<TModel>(entity);
        }
    }
}