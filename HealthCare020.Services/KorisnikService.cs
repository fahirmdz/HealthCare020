using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Core.ServiceModels;
using HealthCare020.Repository;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services

{
    public class KorisnikService : BaseCRUDService<KorisnickiNalogDtoLL, KorisnickiNalogDtoEL, KorisnickiNalogResourceParameters, KorisnickiNalog, KorisnickiNalogUpsertDto, KorisnickiNalogUpsertDto>,
        IKorisnikService
    {
        private readonly ISecurityService _securityService;

        public KorisnikService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            ISecurityService securityService,
            IAuthService authService) : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor,authService)
        {
            _securityService = securityService;
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

        public override async Task<ServiceResult> Insert(KorisnickiNalogUpsertDto request)
        {
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

            return ServiceResult<KorisnickiNalogDtoLL>.OK(_mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog));
        }

        public override async Task<ServiceResult> Update(int id, KorisnickiNalogUpsertDto dtoForUpdate)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);
            if (korisnickiNalog == null)
                return ServiceResult.NotFound("Korisnicki nalog nije pronadjen");

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

            await _dbContext.SaveChangesAsync();

            //Load RoleKorisnickiNalog relations
            await _dbContext.Entry(korisnickiNalog).Collection(x => x.RolesKorisnickiNalog).LoadAsync();

            return ServiceResult<KorisnickiNalogDtoLL>.OK(_mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog));
        }

        public override async Task<ServiceResult> Delete(int id)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);
            if (korisnickiNalog == null)
                return ServiceResult.NotFound("Korisnicki nalog nije pronadjen");

            await Task.Run(() =>
            {
                _dbContext.KorisnickiNalozi.Remove(korisnickiNalog);
            });

            await _dbContext.SaveChangesAsync();

            return ServiceResult<KorisnickiNalogDtoLL>.NoContent();
        }

        public override async Task<PagedList<KorisnickiNalog>> FilterAndPrepare(IQueryable<KorisnickiNalog> result, KorisnickiNalogResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (!string.IsNullOrWhiteSpace(resourceParameters.Username) && await result.AnyAsync())
            {
                result = result.Where(x => x.Username.ToLower().StartsWith(resourceParameters.Username.ToLower()));
            }

            if (resourceParameters.LockedOut)
            {
                result = result.Where(x => x.LockedOut);
            }
            return await base.FilterAndPrepare(result, resourceParameters);
        }

        public override IEnumerable PrepareDataForClient(IEnumerable<KorisnickiNalog> data, KorisnickiNalogResourceParameters resourceParameters)
        {
            foreach (var x in data)
            {
                _dbContext.Entry(x).Collection(c => c.RolesKorisnickiNalog).Load();
            }
            return base.PrepareDataForClient(data, resourceParameters);
        }

        public override T PrepareDataForClient<T>(KorisnickiNalog data)
        {
            _dbContext.Entry(data).Collection(c => c.RolesKorisnickiNalog).Load();
            return _mapper.Map<T>(data);
        }

        public async Task<KorisnickiNalogDtoLL> Authenticate(string username, string password)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FirstOrDefaultAsync(x => x.Username == username);

            if (korisnickiNalog != null)
            {
                var newHash = _securityService.GenerateHash(korisnickiNalog.PasswordSalt, password);

                if (newHash == korisnickiNalog.PasswordHash)
                    return _mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog);
            }
            return null;
        }

        public async Task<ServiceResult> ToggleLock(int id, bool isForLockout, DateTime? until = null)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);

            if (korisnickiNalog == null)
                return ServiceResult.NotFound($"Korisnicki nalog sa ID-em {id} nije pronadjen.");

            korisnickiNalog.LockedOut = isForLockout;
            korisnickiNalog.LockedOutUntil = until;

            await _dbContext.SaveChangesAsync();

            return ServiceResult<KorisnickiNalogDtoLL>.OK(_mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog));
        }

        public async Task<ServiceResult> AddInRoles(int id, KorisnickiNalogRolesUpsertDto request)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);

            if (korisnickiNalog == null)
                return ServiceResult.NotFound($"Korisnicki nalog sa ID-em {id} nije pronadjen.");

            foreach (var roleId in request.Roles)
            {
                if (!await _dbContext.Roles.AnyAsync(x => x.Id == roleId))
                    return ServiceResult.NotFound($"Rola sa ID-em {roleId} nije pronadjena");
                if (await _dbContext.RolesKorisnickiNalozi.AnyAsync(x => x.KorisnickiNalogId == korisnickiNalog.Id && x.RoleId == roleId))
                    return ServiceResult.BadRequest($"Korisnik sa ID-em {id} vec poseduje role sa ID-em {roleId}");
            }

            foreach (var roleId in request.Roles)
            {
                await _dbContext.RolesKorisnickiNalozi.AddAsync(new RoleKorisnickiNalog
                {
                    KorisnickiNalogId = korisnickiNalog.Id,
                    RoleId = roleId
                });
            }
            await _dbContext.SaveChangesAsync();

            await _dbContext.Entry(korisnickiNalog).Collection(x => x.RolesKorisnickiNalog).LoadAsync();

            return new ServiceResult<KorisnickiNalogDtoLL>(_mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog));
        }

        public async Task<ServiceResult> RemoveFromRoles(int id, KorisnickiNalogRolesUpsertDto request)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);

            if (korisnickiNalog == null)
                return ServiceResult.NotFound($"Korisnicki nalog sa ID-em {id} nije pronadjen.");

            foreach (var roleId in request.Roles)
            {
                var roleKorisnickiNalog = await _dbContext.RolesKorisnickiNalozi.FirstOrDefaultAsync(x =>
                    x.RoleId == roleId && korisnickiNalog.Id == x.KorisnickiNalogId);
                if (roleKorisnickiNalog == null)
                {
                    return ServiceResult.BadRequest($"Korisnik sa ID-em {id} ne poseduje role sa ID-em {roleId}");
                }

                await Task.Run(() =>
                {
                    _dbContext.RolesKorisnickiNalozi.Remove(roleKorisnickiNalog);
                });
            }

            await _dbContext.SaveChangesAsync();

            await _dbContext.Entry(korisnickiNalog).Collection(x => x.RolesKorisnickiNalog).LoadAsync();

            return ServiceResult<KorisnickiNalogDtoLL>.OK(_mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog));
        }
    }
}