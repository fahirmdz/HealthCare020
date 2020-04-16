using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface IService<TEntity, TDto, TResourceParameters>
    {
        Task<IList<TDto>> Get(TResourceParameters resourceParameters);

        Task<IList<TDto>> GetWithEagerLoad(TResourceParameters resourceParameters);

        Task<TDto> GetById(int id);

        Task<TDto> FindWithEagerLoad(int id);
    }
}