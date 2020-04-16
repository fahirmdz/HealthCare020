using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.Services.Interfaces
{
    public interface IService<TEntity, TDto, TResourceParameters>
    {
        Task<IEnumerable> Get(TResourceParameters resourceParameters);
        IQueryable<TEntity> GetWithEagerLoad(int? id=null);
        Task<ExpandoObject> GetById(int id,TResourceParameters resourceParameters);

        Task<IEnumerable> FilterAndPrepare(IQueryable<TEntity> result, TResourceParameters resourceParameters);
        Task<ExpandoObject> FilterAndPrepare(TEntity entity, TResourceParameters resourceParameters);
    }
}