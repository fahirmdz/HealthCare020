using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Repository;

namespace HealthCare020.Services
{
    public class DrzavaService: BaseCRUDService<DrzavaModel,DrzavaSearchRequest,Drzava,DrzavaUpsertRequest,DrzavaUpsertRequest>
    {
        public DrzavaService(IMapper mapper, HealthCare020DbContext dbContext) : base(mapper, dbContext)
        {
        }

        
    }
}