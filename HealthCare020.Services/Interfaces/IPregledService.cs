using System;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface IPregledService : ICRUDService<Pregled, PregledDtoLL, PregledDtoEL, PregledResourceParameters, PregledUpsertDto
        , PregledUpsertDto>
    {
        Task<uint> RecommendTimeForPregled(int godistePacijenta);
        Task<DateTime> GetRecommendedVrijemePregleda(int godistePacijenta);
    }
}