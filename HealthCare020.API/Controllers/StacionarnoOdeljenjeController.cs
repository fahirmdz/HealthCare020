using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.API.Controllers
{
    public class StacionarnoOdeljenjeController : BaseCRUDController<StacionarnoOdeljenje, TwoFields, TwoFieldsSearchRequest, StacionarnoOdeljenjeUpsertRequest, StacionarnoOdeljenjeUpsertRequest>
    {
        public StacionarnoOdeljenjeController(ICRUDService<StacionarnoOdeljenje, TwoFields, TwoFieldsSearchRequest, StacionarnoOdeljenjeUpsertRequest, StacionarnoOdeljenjeUpsertRequest> crudService) : base(crudService)
        {
        }
    }
}