using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("/api/zdravstveno-stanje")]
    public class ZdravstvenoStanjeController : BaseCRUDController<ZdravstvenoStanje, TwoFieldsDto, TwoFieldsResourceParameters, ZdravstvenoStanjeUpsertDto, ZdravstvenoStanjeUpsertDto>
    {
        public ZdravstvenoStanjeController(ICRUDService<ZdravstvenoStanje, TwoFieldsDto, TwoFieldsResourceParameters, ZdravstvenoStanjeUpsertDto, ZdravstvenoStanjeUpsertDto> crudService) : base(crudService)
        {
        }
    }
}