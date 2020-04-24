using HealthCare020.Core.Entities;
using HealthCare020.Core.Request;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface IRadnikService
    {
        Task<Radnik> Insert(RadnikUpsertDto radnik);

        Task<Radnik> Update(int id, RadnikUpsertDto radnik);

        Task Delete(int id);
    }
}