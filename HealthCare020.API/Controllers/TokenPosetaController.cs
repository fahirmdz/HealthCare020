using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.API.Controllers
{
    public class TokenPosetaController : BaseCRUDController<TokenPoseta,TwoFields, TwoFieldsSearchRequest,TokenPosetaUpsertRequest, TokenPosetaUpsertRequest>
    {
        public TokenPosetaController(ICRUDService<TokenPoseta, TwoFields, TwoFieldsSearchRequest, TokenPosetaUpsertRequest, TokenPosetaUpsertRequest> crudService) : base(crudService)
        {
        }
    }
}