using HealthCare020.API.Constants;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Authorize(AuthorizationPolicies.DoktorPolicy)]
    [Route("api/"+Routes.DoktoriRoute)]
    public class DoktorController : BaseCRUDController<Doktor, DoktorDtoLL, DoktorDtoEL, DoktorResourceParameters, DoktorUpsertDto, DoktorUpsertDto>
    {
        public DoktorController(ICRUDService<Doktor, DoktorDtoLL, DoktorDtoEL, DoktorResourceParameters, DoktorUpsertDto, DoktorUpsertDto> crudService) : base(crudService)
        {
        }
    }
}