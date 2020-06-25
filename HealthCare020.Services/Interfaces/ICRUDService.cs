using HealthCare020.Core.ServiceModels;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface ICRUDService<TEntity, TDto, TDtoEagerLoaded, TResourceParameters, TDtoForCreation, TDtoForUpdate> : IService<TEntity, TResourceParameters>
    where TDtoForUpdate : class
    {
        Task<ServiceResult> Insert(TDtoForCreation request);

        Task<ServiceResult> Update(int id, TDtoForUpdate request);

        Task<ServiceResult> GetAsUpdateDto(int id);

        Task<ServiceResult> Delete(int id);
    }
}