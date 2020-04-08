using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface IKorisnikService
    {
        Task<IList<KorisnickiNalogModel>> Get(KorisnickiNalogSearchRequest request);

        Task<KorisnickiNalogModel> GetById(int id);

        Task<KorisnickiNalogModel> Insert(KorisnickiNalogUpsertRequest request);

        KorisnickiNalogModel Update(int id, KorisnickiNalogUpsertRequest request);

        KorisnickiNalogModel Delete(int id);

        Task<KorisnickiNalogModel> Authenticate(string username, string password);
    }
}