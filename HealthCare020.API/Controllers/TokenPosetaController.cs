using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/"+Routes.TokeniPosetaRoute)]
    public class TokenPosetaController : BaseCRUDController<TokenPoseta,TokenPosetaDtoLL,TokenPosetaDtoEL, TokenPosetaResourceParameters,TokenPosetaUpsertDto, TokenPosetaUpsertDto>
    {
        public TokenPosetaController(ICRUDService<TokenPoseta, TokenPosetaDtoLL, TokenPosetaDtoEL, TokenPosetaResourceParameters, TokenPosetaUpsertDto, TokenPosetaUpsertDto> crudService) : base(crudService)
        {
        }
    }
}