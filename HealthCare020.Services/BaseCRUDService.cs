using AutoMapper;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Interfaces;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class BaseCRUDService<TModel, TSearch, TEntity, TInsert, TUpdate> : BaseService<TModel, TSearch, TEntity>, ICRUDService<TEntity, TModel, TSearch, TInsert, TUpdate> where TEntity : class
    {
        public BaseCRUDService(IMapper mapper, HealthCare020DbContext dbContext) : base(mapper, dbContext)
        {
        }

        public virtual async Task<TModel> Insert(TInsert request)
        {
            var entity = _mapper.Map<TEntity>(request);

            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var query = _dbContext.Set<TEntity>();
            var entity = query.Find(id);
            if (entity == null)
                throw new NotFoundException("Not Found");

            entity = _mapper.Map(request, entity);

            query.Update(entity);
            _dbContext.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Delete(int id)
        {
            var query = _dbContext.Set<TEntity>();

            var entity = query.Find(id);

            if (entity == null)
                throw new NotFoundException("Not Found");

            query.Remove(entity);
            _dbContext.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }
    }
}