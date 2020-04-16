using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthCare020.Core.ResourceParameters;

namespace HealthCare020.Services.Interfaces
{
    public interface IKorisnikService
    {
        Task<IList<KorisnickiNalogDto>> Get(KorisnickiNalogResourceParameters request);

        Task<KorisnickiNalogDto> GetById(int id);

        Task<KorisnickiNalogDto> Insert(KorisnickiNalogUpsertDto request);

        KorisnickiNalogDto Update(int id, KorisnickiNalogUpsertDto request);

        KorisnickiNalogDto Delete(int id);

        Task<KorisnickiNalogDto> Authenticate(string username, string password);
    }
}