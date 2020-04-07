using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.API.Controllers
{
    public class TokenPosetaController : BaseCRUDController<TwoFields, TwoFieldsSearchRequest, TokenPosetaUpsertRequest, TokenPosetaUpsertRequest>
    {
        public TokenPosetaController(ICRUDService<TwoFields, TwoFieldsSearchRequest, TokenPosetaUpsertRequest, TokenPosetaUpsertRequest> crudService) : base(crudService)
        {
        }
    }
}