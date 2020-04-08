using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Repository.Interfaces;

namespace HealthCare020.Services
{
    public class GradService:BaseCRUDService<GradModel,GradSearchRequest,Grad,GradUpsertRequest,GradUpsertRequest>
    {
        public GradService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            children = new[] {nameof(Grad.Drzava)};
            filterForId = x => x.Id == TempId;
        }
    }
}