using System;
using System.Collections.Generic;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using System.Threading.Tasks;
using HealthCare020.Core.ServiceModels;

namespace HealthCare020.Services.Interfaces
{
    public interface IKorisnikService :ICRUDService<KorisnickiNalog,KorisnickiNalogDtoLL,KorisnickiNalogDtoEL,KorisnickiNalogResourceParameters,KorisnickiNalogUpsertDto,KorisnickiNalogUpsertDto>
    {
        Task<KorisnickiNalogDtoLL> Authenticate(string username, string password);
        Task<ServiceResult<KorisnickiNalogDtoLL>> ToggleLock(int id, bool isForLockout, DateTime? until = null);
        Task<ServiceResult<KorisnickiNalogDtoLL>> AddInRoles(int id, KorisnickiNalogRolesUpsertDto request);
        Task<ServiceResult<KorisnickiNalogDtoLL>> RemoveFromRoles(int id, KorisnickiNalogRolesUpsertDto request);
    }
}