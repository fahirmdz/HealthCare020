using HealthCare020.Core.Request;
using HealthCare020.Core.ServiceModels;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface IRadnikService
    {
        Task<ServiceResult> Insert(RadnikUpsertDto radnik);

        Task<ServiceResult> Update(int id, RadnikUpsertDto radnik);

        Task<ServiceResult> Delete(int id);
    }
}