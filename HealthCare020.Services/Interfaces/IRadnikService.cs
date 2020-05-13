using HealthCare020.Core.Entities;
using HealthCare020.Core.Request;
using System.Threading.Tasks;
using HealthCare020.Core.ServiceModels;

namespace HealthCare020.Services.Interfaces
{
    public interface IRadnikService
    {
        Task<ServiceResult<Radnik>> Insert(RadnikUpsertDto radnik);

        Task<ServiceResult<Radnik>> Update(int id, RadnikUpsertDto radnik);

        Task<ServiceResult<Radnik>> Delete(int id);
    }
}