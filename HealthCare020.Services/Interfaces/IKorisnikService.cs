using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Core.ServiceModels;
using System;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface IKorisnikService : ICRUDService<KorisnickiNalog, KorisnickiNalogDtoLL, KorisnickiNalogDtoEL, KorisnickiNalogResourceParameters, KorisnickiNalogUpsertDto, KorisnickiNalogUpsertDto>
    {
        Task<KorisnickiNalogDtoLL> Authenticate(string username, string password);

        Task<KorisnickiNalogDtoLL> Authenticate(byte[] imageToIdentity);

        Task<ServiceResult> ToggleLock(int id, bool isForLockout, DateTime? until = null);

        Task<ServiceResult> AddInRoles(int id, KorisnickiNalogRolesUpsertDto request);

        Task<ServiceResult> RemoveFromRoles(int id, KorisnickiNalogRolesUpsertDto request);

        Task<ServiceResult> ChangePassword(string currentPassword, string newPassword);

        Task<ServiceResult> CheckPassword(string password);

        Task<ServiceResult> AccountLocked(string username, string password);
    }
}