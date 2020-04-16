using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.API.Controllers
{
    public class DrzavaController : BaseCRUDController<Drzava,DrzavaDto, DrzavaResourceParameters, DrzavaUpsertRequest, DrzavaUpsertRequest>
    {
        public DrzavaController(ICRUDService<Drzava, DrzavaDto, DrzavaResourceParameters, DrzavaUpsertRequest, DrzavaUpsertRequest> crudService) : base(crudService)
        {
        }
    }
}