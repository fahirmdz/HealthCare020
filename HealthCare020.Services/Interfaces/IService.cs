using HealthCare020.Core.ServiceModels;
using HealthCare020.Services.Helpers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface IService<TEntity, TResourceParameters>
    {
        Task<ServiceResult<SequenceResult>> Get(TResourceParameters resourceParameters);

        IQueryable<TEntity> GetWithEagerLoad(int? id = null);

        Task<ServiceResult<dynamic>> GetById(int id, bool EagerLoaded);

        Task<PagedList<TEntity>> FilterAndPrepare(IQueryable<TEntity> result, TResourceParameters resourceParameters);

        IEnumerable PrepareDataForClient(IEnumerable<TEntity> data, TResourceParameters resourceParameters);

        bool ShouldEagerLoad(TResourceParameters resourceParameters);
    }
}