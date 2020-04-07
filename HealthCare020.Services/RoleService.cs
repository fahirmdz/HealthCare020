using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Repository.Interfaces;

namespace HealthCare020.Services
{
    public class RoleService:BaseCRUDService<TwoFields,TwoFieldsSearchRequest,Role,RoleUpsertRequest,RoleUpsertRequest>
    {
        public RoleService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }
    }
}