using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("/api/zdravstvena-stanja")]
    public class ZdravstvenoStanjeController : BaseCRUDController<ZdravstvenoStanje, ZdravstvenoStanjeDto,ZdravstvenoStanjeDto,ZdravstvenoStanjeResourceParameters, ZdravstvenoStanjeUpsertDto, ZdravstvenoStanjeUpsertDto>
    {
        public ZdravstvenoStanjeController(ICRUDService<ZdravstvenoStanje, ZdravstvenoStanjeDto,ZdravstvenoStanjeDto, ZdravstvenoStanjeResourceParameters, ZdravstvenoStanjeUpsertDto, ZdravstvenoStanjeUpsertDto> crudService) : base(crudService)
        {
        }
    }
}