using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/" + Routes.LekarskoUverenjeRoute)]
    public class LekarskoUverenjeController : BaseCRUDController<LekarskoUverenje, LekarskoUverenjeDtoLL, LekarskoUverenjeDtoEL, LekarskoUverenjeResourceParameters, LekarskoUverenjeUpsertDto, LekarskoUverenjeUpsertDto>
    {
        public LekarskoUverenjeController(ICRUDService<LekarskoUverenje, LekarskoUverenjeDtoLL, LekarskoUverenjeDtoEL, LekarskoUverenjeResourceParameters, LekarskoUverenjeUpsertDto, LekarskoUverenjeUpsertDto> crudService) : base(crudService)
        {
        }
    }
}