using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface IKorisnikService : IService<KorisnickiNalog, KorisnickiNalogResourceParameters>
    {
        Task<KorisnickiNalogDtoLL> Authenticate(string username, string password);

        Task<KorisnickiNalogDtoLL> Insert(KorisnickiNalogUpsertDto request);

        Task<KorisnickiNalogDtoLL> Update(int id, KorisnickiNalogUpsertDto request);

        Task Delete(int id);
    }
}