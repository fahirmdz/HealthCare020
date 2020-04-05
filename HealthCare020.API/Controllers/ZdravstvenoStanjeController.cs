using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZdravstvenoStanjeController : BaseCRUDController<TwoFields,TwoFieldsSearchRequest,ZdravstvenoStanjeUpsertRequest,ZdravstvenoStanjeUpsertRequest>
    {
        public ZdravstvenoStanjeController(ICRUDService<TwoFields, TwoFieldsSearchRequest, ZdravstvenoStanjeUpsertRequest, ZdravstvenoStanjeUpsertRequest> crudService) : base(crudService)
        {
        }
    }
}