using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Repository;

namespace HealthCare020.Services
{
    public class TokenPosetaService: BaseCRUDService<TwoFields,TwoFieldsSearchRequest,TokenPoseta,TokenPosetaUpsertRequest,TokenPosetaUpsertRequest>
    {
        public TokenPosetaService(IMapper mapper, HealthCare020DbContext dbContext) : base(mapper, dbContext)
        {
        }
    }
}