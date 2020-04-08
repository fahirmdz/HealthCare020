using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.API.Controllers
{
    public class LicniPodaciController : BaseCRUDController<LicniPodaci, LicniPodaciModel, LicniPodaciSearchRequest, LicniPodaciUpsertRequest, LicniPodaciUpsertRequest>
    {
        public LicniPodaciController(ICRUDService<LicniPodaci, LicniPodaciModel, LicniPodaciSearchRequest, LicniPodaciUpsertRequest, LicniPodaciUpsertRequest> crudService) : base(crudService)
        {
        }
    }
}