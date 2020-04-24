using System.Threading.Tasks;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/radnici-prijem")]
    public class RadnikPrijemController : BaseCRUDController<RadnikPrijem, RadnikPrijemDtoLL,RadnikPrijemDtoEL, RadnikPrijemResourceParameters, RadnikPrijemUpsertDto, RadnikPrijemUpsertDto>
    {
        public RadnikPrijemController(ICRUDService<RadnikPrijem, RadnikPrijemDtoLL, RadnikPrijemDtoEL, RadnikPrijemResourceParameters, RadnikPrijemUpsertDto, RadnikPrijemUpsertDto> crudService) : base(crudService)
        {
        }
    }
}