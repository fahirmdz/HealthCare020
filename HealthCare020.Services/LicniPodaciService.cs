using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Repository.Interfaces;

namespace HealthCare020.Services
{
    public class LicniPodaciService: BaseCRUDService<LicniPodaciModel,LicniPodaciSearchRequest,LicniPodaci,LicniPodaciUpsertRequest,LicniPodaciUpsertRequest>
    {
        public LicniPodaciService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            children = new[] {nameof(LicniPodaci.Grad)};
            filterForId = x => x.Id == TempId;
        }
    }
}