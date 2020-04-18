using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface IKorisnikService : IService<KorisnickiNalog, KorisnickiNalogResourceParameters>
    {
        Task<KorisnickiNalogDtoLazyLoaded> Authenticate(string username, string password);

        Task<KorisnickiNalogDtoLazyLoaded> Insert(KorisnickiNalogUpsertDto request);

        KorisnickiNalogDtoLazyLoaded Update(int id, KorisnickiNalogUpsertDto request);

        void Delete(int id);
    }
}