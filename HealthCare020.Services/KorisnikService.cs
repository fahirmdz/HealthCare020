using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Enums;
using HealthCare020.Core.Extensions;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Core.ServiceModels;
using HealthCare020.Repository;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using HealthCare020.Services.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HealthCare020.Core.Security;

namespace HealthCare020.Services

{
    public class KorisnikService : BaseCRUDService<KorisnickiNalogDtoLL, KorisnickiNalogDtoEL, KorisnickiNalogResourceParameters, KorisnickiNalog, KorisnickiNalogUpsertDto, KorisnickiNalogUpsertDto>,
        IKorisnikService
    {
        private readonly ISecurityService _securityService;
        private readonly IFaceRecognitionService _faceRecognitionService;

        public KorisnikService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            ISecurityService securityService,
            IAuthService authService,
            IFaceRecognitionService faceRecognitionService)
            : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor, authService)
        {
            _securityService = securityService;
            _faceRecognitionService = faceRecognitionService;
        }

        public override IQueryable<KorisnickiNalog> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.KorisnickiNalozi
                .Include(x => x.RolesKorisnickiNalog)
                .ThenInclude(x => x.Role)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<ServiceResult> GetById(int id, bool EagerLoaded)
        {
            if (id == 0)
            {
                var user = await _authService.LoggedInUser();
                if (user == null)
                    return ServiceResult.Unauthorized();

                var korisnikFromDb = await _dbContext.KorisnickiNalozi.Include(x => x.RolesKorisnickiNalog)
                    .FirstOrDefaultAsync(x => x.Id == user.Id);

                return ServiceResult.OK(_mapper.Map<KorisnickiNalogDtoLL>(korisnikFromDb));
            }
            return await base.GetById(id, EagerLoaded);
        }

        public override async Task<ServiceResult> Insert(KorisnickiNalogUpsertDto request)
        {
            if (await ValidateModel(request) is { } validationResult && !validationResult.Succeeded)
                return ServiceResult.WithStatusCode(validationResult.StatusCode, validationResult.Message);

            var korisnickiNalog = _mapper.Map<KorisnickiNalog>(request);

            if (request.ConfirmPassword != request.Password)
            {
                return ServiceResult.BadRequest("Lozinke se ne podudaraju");
            }

            korisnickiNalog.PasswordSalt = _securityService.GenerateSalt();
            korisnickiNalog.PasswordHash = _securityService.GenerateHash(korisnickiNalog.PasswordSalt, request.Password);

            korisnickiNalog.DateCreated = DateTime.Now;
            korisnickiNalog.LastOnline = DateTime.Now;

            await _dbContext.KorisnickiNalozi.AddAsync(korisnickiNalog);
            await _dbContext.SaveChangesAsync();

            var roleType = RoleTypeManager.RoleTypeFromString(request.RoleType);

            if (roleType.HasValue)
                await AddInRole(korisnickiNalog.Id, roleType.Value);

            return ServiceResult.OK(_mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog));
        }

        public override async Task<ServiceResult> Update(int id, KorisnickiNalogUpsertDto dtoForUpdate)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);
            if (korisnickiNalog == null)
                return ServiceResult.NotFound("Korisnicki nalog nije pronadjen");

            if (await ValidateModel(dtoForUpdate) is { } validationResult && !validationResult.Succeeded)
                return ServiceResult.WithStatusCode(validationResult.StatusCode, validationResult.Message);

            _mapper.Map(dtoForUpdate, korisnickiNalog);

            if (!string.IsNullOrEmpty(dtoForUpdate.Password) && dtoForUpdate.Password != dtoForUpdate.ConfirmPassword)
                return ServiceResult.BadRequest("Lozinke se ne podudaraju");

            await Task.Run(() =>
            {
                korisnickiNalog.PasswordSalt = _securityService.GenerateSalt();
                korisnickiNalog.PasswordHash = _securityService.GenerateHash(korisnickiNalog.PasswordSalt, dtoForUpdate.Password);

                korisnickiNalog.DateCreated = DateTime.Now;
                korisnickiNalog.LastOnline = DateTime.Now;

                _dbContext.KorisnickiNalozi.Update(korisnickiNalog);
            });

            var roleType = RoleTypeManager.RoleTypeFromString(dtoForUpdate.RoleType);

            if (roleType.HasValue)
                await AddInRole(id, roleType.Value);

            await _dbContext.SaveChangesAsync();

            //Load RoleKorisnickiNalog relations
            await _dbContext.Entry(korisnickiNalog).Collection(x => x.RolesKorisnickiNalog).LoadAsync();

            return ServiceResult.OK(_mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog));
        }

        public override async Task<ServiceResult> Delete(int id)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);
            if (korisnickiNalog == null)
                return ServiceResult.NotFound("Korisnicki nalog nije pronadjen");

            await _faceRecognitionService.DeletePersonFromGroup(Guid.Parse(korisnickiNalog.FaceId),
                Resources.FaceAPI_PersonGroupId);

            var rolesToDelete = _dbContext.RolesKorisnickiNalozi.Where(x => x.KorisnickiNalogId == korisnickiNalog.Id).ToList();
            if (rolesToDelete.Any())
                _dbContext.RemoveRange(rolesToDelete);

            await Task.Run(() =>
            {
                _dbContext.KorisnickiNalozi.Remove(korisnickiNalog);
            });

            await _dbContext.SaveChangesAsync();

            return ServiceResult.NoContent();
        }

        public override async Task<PagedList<KorisnickiNalog>> FilterAndPrepare(IQueryable<KorisnickiNalog> result, KorisnickiNalogResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (resourceParameters != null)
            {
                if (!string.IsNullOrWhiteSpace(resourceParameters.Username) && await result.AnyAsync())
                {
                    result = result.Where(x => x.Username.ToLower().StartsWith(resourceParameters.Username.ToLower()));
                }

                if (resourceParameters.LockedOut)
                {
                    result = result.Where(x => x.LockedOut);
                }
            }
            return await base.FilterAndPrepare(result, resourceParameters);
        }

        public override IEnumerable PrepareDataForClient(IEnumerable<KorisnickiNalog> data, KorisnickiNalogResourceParameters resourceParameters)
        {
            var korisnickiNalogs = data.ToList();
            foreach (var x in korisnickiNalogs)
            {
                _dbContext.Entry(x).Collection(c => c.RolesKorisnickiNalog).Load();
            }
            return base.PrepareDataForClient(korisnickiNalogs, resourceParameters);
        }

        public override T PrepareDataForClient<T>(KorisnickiNalog data)
        {
            _dbContext.Entry(data).Collection(c => c.RolesKorisnickiNalog).Load();
            return _mapper.Map<T>(data);
        }

        public async Task<KorisnickiNalogDtoLL> Authenticate(string username, string password)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi
                .Include(x => x.RolesKorisnickiNalog)
                .FirstOrDefaultAsync(x => x.Username == username);

            if (korisnickiNalog != null)
            {
                var newHash = _securityService.GenerateHash(korisnickiNalog.PasswordSalt, password);

                if (newHash == korisnickiNalog.PasswordHash)
                    return _mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog);
            }
            return null;
        }

        public async Task<KorisnickiNalogDtoLL> Authenticate(byte[] imageToIdentity)
        {
            var stream = new MemoryStream(imageToIdentity);
            var identifiedPersonGuid = await _faceRecognitionService.IdentifyFace(stream, Resources.FaceAPI_PersonGroupId);
            if (!identifiedPersonGuid.HasValue)
                return null;

            var personGuid = identifiedPersonGuid.ToString();

            var korisnici = _dbContext.KorisnickiNalozi.ToList();
            var korisnickiNalog =
                await _dbContext.KorisnickiNalozi.FirstOrDefaultAsync(x => x.FaceId.Equals(personGuid));
            if (korisnickiNalog == null)
                return null;

            return _mapper.Map<KorisnickiNalog, KorisnickiNalogDtoLL>(korisnickiNalog);
        }

        public async Task<ServiceResult> ToggleLock(int id, bool isForLockout, DateTime? until = null)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);

            if (korisnickiNalog == null)
                return ServiceResult.NotFound($"Korisnicki nalog sa ID-em {id} nije pronadjen.");

            korisnickiNalog.LockedOut = isForLockout;
            korisnickiNalog.LockedOutUntil = until;

            await _dbContext.SaveChangesAsync();

            return ServiceResult.OK(_mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog));
        }

        public async Task<ServiceResult> AddInRoles(int id, KorisnickiNalogRolesUpsertDto request)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);

            if (korisnickiNalog == null)
                return ServiceResult.NotFound($"Korisnicki nalog sa ID-em {id} nije pronadjen.");

            if (!await _dbContext.Roles.AnyAsync(x => x.Id == request.RoleId))
                return ServiceResult.NotFound($"Rola sa ID-em {request.RoleId} nije pronadjena.");

            var rolesToAdd = RolesToAdd((RoleType)request.RoleId); //Roles sa manje persmisija, a koje se dodaju uz role sa vecim permisijama

            var oldRoles = _dbContext.RolesKorisnickiNalozi.Where(x => x.KorisnickiNalog.Id == korisnickiNalog.Id);
            if (await oldRoles.AnyAsync())
                _dbContext.RemoveRange(oldRoles);

            foreach (var roleId in rolesToAdd)
            {
                await _dbContext.RolesKorisnickiNalozi.AddAsync(new RoleKorisnickiNalog
                {
                    KorisnickiNalogId = korisnickiNalog.Id,
                    RoleId = roleId.ToInt()
                });
                await _dbContext.SaveChangesAsync();
            }

            await _dbContext.Entry(korisnickiNalog).Collection(x => x.RolesKorisnickiNalog).LoadAsync();

            return new ServiceResult(_mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog));
        }

        public async Task<ServiceResult> RemoveFromRoles(int id, KorisnickiNalogRolesUpsertDto request)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);

            if (korisnickiNalog == null)
                return ServiceResult.NotFound($"Korisnicki nalog sa ID-em {id} nije pronadjen.");

            var roleKorisnickiNalog = await _dbContext.RolesKorisnickiNalozi.FirstOrDefaultAsync(x =>
                x.RoleId == request.RoleId && korisnickiNalog.Id == x.KorisnickiNalogId);
            if (roleKorisnickiNalog == null)
            {
                return ServiceResult.BadRequest($"Korisnik sa ID-em {id} ne poseduje role sa ID-em {request.RoleId}");
            }

            await Task.Run(() =>
            {
                _dbContext.RolesKorisnickiNalozi.Remove(roleKorisnickiNalog);
            });

            await _dbContext.SaveChangesAsync();

            await _dbContext.Entry(korisnickiNalog).Collection(x => x.RolesKorisnickiNalog).LoadAsync();

            return ServiceResult.OK(_mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog));
        }

        public async Task<ServiceResult> ChangePassword(string currentPassword, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword))
                return ServiceResult.BadRequest();

            currentPassword = currentPassword.RemoveWhitespaces();
            newPassword = newPassword.RemoveWhitespaces();

            var currentUser = await _authService.LoggedInUser();

            var userFromDb = await _dbContext.KorisnickiNalozi.FindAsync(currentUser.Id);
            var hashedCurrentPassword = _securityService.GenerateHash(userFromDb.PasswordSalt, currentPassword);
            if (userFromDb.PasswordHash != hashedCurrentPassword)
                return ServiceResult.BadRequest("Netačna trenutna lozinka");

            userFromDb.PasswordSalt = _securityService.GenerateSalt();
            var hash = _securityService.GenerateHash(userFromDb.PasswordSalt, newPassword);
            userFromDb.PasswordHash = hash;
            await _dbContext.SaveChangesAsync();

            return ServiceResult.OK();
        }

        public async Task<ServiceResult> CheckPassword(string password)
        {
            var user = await _authService.LoggedInUser();
            if (user == null)
                return ServiceResult.Unauthorized();

            if (user.PasswordHash == _securityService.GenerateHash(user.PasswordSalt, password))
                return ServiceResult.OK();

            return ServiceResult.BadRequest(Resources.IncorrectPassword);
        }

        public async Task<ServiceResult> AccountLocked(string username, string password)
        {
            var user = await Authenticate(username, password);
            if (user == null)
                return ServiceResult.BadRequest("Korisnicki nalog nije pronadjen");

            if (user.LockedOut)
                return ServiceResult.WithStatusCode(HttpStatusCode.Locked);

            return ServiceResult.OK();
        }

        private List<RoleType> RolesToAdd(RoleType roleParent)
        {
            switch (roleParent)
            {
                case RoleType.Administrator:
                    return new List<RoleType> { RoleType.Administrator, RoleType.Doktor, RoleType.MedicinskiTehnicar, RoleType.RadnikPrijem, RoleType.Pacijent };

                case RoleType.Doktor:
                    return new List<RoleType> { RoleType.Doktor, RoleType.MedicinskiTehnicar, RoleType.RadnikPrijem, RoleType.Pacijent };

                case RoleType.MedicinskiTehnicar:
                    return new List<RoleType> { RoleType.MedicinskiTehnicar, RoleType.RadnikPrijem, RoleType.Pacijent };

                case RoleType.RadnikPrijem:
                    return new List<RoleType> { RoleType.RadnikPrijem, RoleType.Pacijent };

                default:
                    return new List<RoleType> { RoleType.Pacijent };
            }
        }

        private async Task<ServiceResult> AddInRole(int korisnickiNalogId, RoleType roleType)
        {
            var rolesToAdd = RolesToAdd(roleType);
            foreach (var roleId in rolesToAdd)
            {
                await _dbContext.RolesKorisnickiNalozi.AddAsync(new RoleKorisnickiNalog
                {
                    KorisnickiNalogId = korisnickiNalogId,
                    RoleId = roleId.ToInt()
                });
            }

            await _dbContext.SaveChangesAsync();

            return ServiceResult.WithStatusCode(HttpStatusCode.OK);
        }

        private async Task<ServiceResult> ValidateModel(KorisnickiNalogUpsertDto dto)
        {
            if (dto == null)
                return ServiceResult.BadRequest();

            if (await _dbContext.KorisnickiNalozi.AnyAsync(x => x.Username.ToLower() == dto.Username.ToLower()))
                return ServiceResult.BadRequest($"Vec postoji korisnicki nalog koji koristi username {dto.Username}.");

            return ServiceResult.WithStatusCode(HttpStatusCode.OK);
        }
    }
}