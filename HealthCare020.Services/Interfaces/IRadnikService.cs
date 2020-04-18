using HealthCare020.Core.Entities;
using System.Threading.Tasks;
using HealthCare020.Core.Request;

namespace HealthCare020.Services.Interfaces
{
    public interface IRadnikService
    {
        Task<Radnik> Insert(RadnikUpsertDto radnik);

        Radnik Update(int id, RadnikUpsertDto radnik);

        void Delete(int id);
    }
}