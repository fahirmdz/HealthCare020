using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.API.Controllers
{
    public class DrzavaController : BaseCRUDController<Drzava,DrzavaModel, DrzavaSearchRequest, DrzavaUpsertRequest, DrzavaUpsertRequest>
    {
        public DrzavaController(ICRUDService<Drzava, DrzavaModel, DrzavaSearchRequest, DrzavaUpsertRequest, DrzavaUpsertRequest> crudService) : base(crudService)
        {
        }
    }
}