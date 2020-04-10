using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Repository;

namespace HealthCare020.Services
{
    public class StacionarnoOdeljenjeService: BaseCRUDService<TwoFields,TwoFieldsSearchRequest,StacionarnoOdeljenje,StacionarnoOdeljenjeUpsertRequest,StacionarnoOdeljenjeUpsertRequest>
    {
        public StacionarnoOdeljenjeService(IMapper mapper, HealthCare020DbContext dbContext) : base(mapper, dbContext)
        {
        }
    }
}