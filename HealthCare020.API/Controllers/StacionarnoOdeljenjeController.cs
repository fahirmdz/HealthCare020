using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/"+Routes.StacionarnaOdeljenjaRoute)]
    public class StacionarnoOdeljenjeController : BaseCRUDController<StacionarnoOdeljenje, TwoFieldsDto, TwoFieldsDto, TwoFieldsResourceParameters, StacionarnoOdeljenjeUpsertDto, StacionarnoOdeljenjeUpsertDto>
    {
        public StacionarnoOdeljenjeController(ICRUDService<StacionarnoOdeljenje, TwoFieldsDto, TwoFieldsDto, TwoFieldsResourceParameters, StacionarnoOdeljenjeUpsertDto, StacionarnoOdeljenjeUpsertDto> crudService) : base(crudService)
        {
        }
    }
}