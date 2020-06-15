using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Constants;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/" + Routes.PacijentNaLecenjuRoute)]
    [Authorize(AuthorizationPolicies.RadnikPrijemPolicy)] //At least
    public class PacijentNaLecenjuController : BaseCRUDController<PacijentNaLecenju, PacijentNaLecenjuDtoLL, PacijentNaLecenjuDtoEL, PacijentNaLecenjuResourceParameters, PacijentNaLecenjuUpsertDto, PacijentNaLecenjuUpsertDto>
    {
        public PacijentNaLecenjuController(ICRUDService<PacijentNaLecenju, PacijentNaLecenjuDtoLL, PacijentNaLecenjuDtoEL,
            PacijentNaLecenjuResourceParameters, PacijentNaLecenjuUpsertDto, PacijentNaLecenjuUpsertDto> crudService)
            : base(crudService)
        {
        }
    }
}