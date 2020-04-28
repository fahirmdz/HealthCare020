using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace HealthCare020.Services.Interfaces
{
    public interface ICRUDService<TEntity, TDto, TDtoEagerLoaded, TResourceParameters,TDtoForCreation,TDtoForUpdate>:IService<TEntity,TResourceParameters>
    where TDtoForUpdate: class
    {
        Task<TDto> Insert(TDtoForCreation request);

        Task<TDto> Update(int id, TDtoForUpdate request);

        Task<TDtoForUpdate> GetAsUpdateDto(int id);

        Task Delete(int id);
    }
}