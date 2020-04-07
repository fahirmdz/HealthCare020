using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.API.Controllers
{
    public class DrzavaController : BaseCRUDController<DrzavaModel, DrzavaSearchRequest, DrzavaUpsertRequest, DrzavaUpsertRequest>
    {
        public DrzavaController(ICRUDService<DrzavaModel, DrzavaSearchRequest, DrzavaUpsertRequest, DrzavaUpsertRequest> crudService) : base(crudService)
        {
        }
    }
}