using HealthCare020.Core.ServiceModels;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface ICRUDService<TEntity, TDto, TDtoEagerLoaded, TResourceParameters, TDtoForCreation, TDtoForUpdate> : IService<TEntity, TResourceParameters>
    where TDtoForUpdate : class
    {
        Task<ServiceResult<TDto>> Insert(TDtoForCreation request);

        Task<ServiceResult<TDto>> Update(int id, TDtoForUpdate request);

        Task<ServiceResult<TDtoForUpdate>> GetAsUpdateDto(int id);

        Task<ServiceResult<TDto>> Delete(int id);
    }
}