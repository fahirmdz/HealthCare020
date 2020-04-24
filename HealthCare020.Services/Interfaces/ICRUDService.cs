using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface ICRUDService<TEntity, TDto, TDtoEagerLoaded, TResourceParameters,TDtoForCreation,TDtoForUpdate>:IService<TEntity,TResourceParameters>
    {
        Task<TDto> Insert(TDtoForCreation request);

        Task<TDto> Update(int id, TDtoForUpdate request);

        Task Delete(int id);
    }
}