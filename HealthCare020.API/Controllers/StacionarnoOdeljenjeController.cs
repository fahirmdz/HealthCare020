using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace HealthCare020.API.Controllers
{
    [Route("/api/stacionarno-odeljenje")]
    public class StacionarnoOdeljenjeController : BaseCRUDController<StacionarnoOdeljenje, TwoFieldsDto, TwoFieldsResourceParameters, StacionarnoOdeljenjeUpsertDto, StacionarnoOdeljenjeUpsertDto>
    {
        public StacionarnoOdeljenjeController(ICRUDService<StacionarnoOdeljenje, TwoFieldsDto, TwoFieldsResourceParameters, StacionarnoOdeljenjeUpsertDto, StacionarnoOdeljenjeUpsertDto> crudService) : base(crudService)
        {
        }
    }
}