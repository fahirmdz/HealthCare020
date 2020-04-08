using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.API.Controllers
{
    public class ZdravstvenoStanjeController : BaseCRUDController<ZdravstvenoStanje, TwoFields, TwoFieldsSearchRequest, ZdravstvenoStanjeUpsertRequest, ZdravstvenoStanjeUpsertRequest>
    {
        public ZdravstvenoStanjeController(ICRUDService<ZdravstvenoStanje, TwoFields, TwoFieldsSearchRequest, ZdravstvenoStanjeUpsertRequest, ZdravstvenoStanjeUpsertRequest> crudService) : base(crudService)
        {
        }
    }
}