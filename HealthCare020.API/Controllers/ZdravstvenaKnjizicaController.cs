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
    [Route("api/" + Routes.ZdravstvenaKnjizicaRoute)]
    [Authorize(AuthorizationPolicies.MedicinskiTehnicarPolicy)]
    public class ZdravstvenaKnjizicaController : BaseCRUDController<ZdravstvenaKnjizica, ZdravstvenaKnjizicaDtoLL, ZdravstvenaKnjizicaDtoEL, ZdravstvenaKnjizicaResourceParameters, ZdravstvenaKnjizicaUpsertDto, ZdravstvenaKnjizicaUpsertDto>
    {
        public ZdravstvenaKnjizicaController(ICRUDService<ZdravstvenaKnjizica, ZdravstvenaKnjizicaDtoLL, ZdravstvenaKnjizicaDtoEL, ZdravstvenaKnjizicaResourceParameters, ZdravstvenaKnjizicaUpsertDto, ZdravstvenaKnjizicaUpsertDto> crudService) : base(crudService)
        {
        }
    }
}