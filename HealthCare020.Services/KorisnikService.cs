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
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare020.Services

{
    public class KorisnikService : BaseCRUDService<KorisnickiNalogDtoLL, KorisnickiNalogDtoEL, KorisnickiNalogResourceParameters, KorisnickiNalog, KorisnickiNalogUpsertDto, KorisnickiNalogUpsertDto>,
        IKorisnikService
    {
        public KorisnikService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor)
            : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor)
        {
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

        public override async Task<ServiceResult<KorisnickiNalogDtoLL>> Insert(KorisnickiNalogUpsertDto request)
        {
            var korisnickiNalog = _mapper.Map<KorisnickiNalog>(request);

            if (request.ConfirmPassword != request.Password)
            {
                return new ServiceResult<KorisnickiNalogDtoLL>(HttpStatusCode.BadRequest, "Lozinke se ne podudaraju");
            }

            korisnickiNalog.PasswordSalt = GenerateSalt();
            korisnickiNalog.PasswordHash = GenerateHash(korisnickiNalog.PasswordSalt, request.Password);

            korisnickiNalog.DateCreated = DateTime.Now;
            korisnickiNalog.LastOnline = DateTime.Now;

            await _dbContext.KorisnickiNalozi.AddAsync(korisnickiNalog);
            await _dbContext.SaveChangesAsync();

            return new ServiceResult<KorisnickiNalogDtoLL>(_mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog));
        }

        public override async Task<ServiceResult<KorisnickiNalogDtoLL>> Update(int id, KorisnickiNalogUpsertDto dtoForUpdate)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);
            if (korisnickiNalog == null)
                return new ServiceResult<KorisnickiNalogDtoLL>(HttpStatusCode.NotFound, "Korisnicki nalog nije pronadjen");

            _mapper.Map(dtoForUpdate, korisnickiNalog);

            if (!string.IsNullOrEmpty(dtoForUpdate.Password) && dtoForUpdate.Password != dtoForUpdate.ConfirmPassword)
                return new ServiceResult<KorisnickiNalogDtoLL>(HttpStatusCode.BadRequest, "Lozinke se ne podudaraju");

            await Task.Run(() =>
            {
                korisnickiNalog.PasswordSalt = GenerateSalt();
                korisnickiNalog.PasswordHash = GenerateHash(korisnickiNalog.PasswordSalt, dtoForUpdate.Password);

                korisnickiNalog.DateCreated = DateTime.Now;
                korisnickiNalog.LastOnline = DateTime.Now;

                _dbContext.KorisnickiNalozi.Update(korisnickiNalog);
            });

            await _dbContext.SaveChangesAsync();

            //Load RoleKorisnickiNalog relations
            await _dbContext.Entry(korisnickiNalog).Collection(x => x.RolesKorisnickiNalog).LoadAsync();

            return new ServiceResult<KorisnickiNalogDtoLL>(_mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog));
        }

        public override async Task<ServiceResult<KorisnickiNalogDtoLL>> Delete(int id)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);
            if (korisnickiNalog == null)
                return new ServiceResult<KorisnickiNalogDtoLL>(HttpStatusCode.NotFound, "Korisnicki nalog nije pronadjen");

            await Task.Run(() =>
            {
                _dbContext.KorisnickiNalozi.Remove(korisnickiNalog);
            });

            await _dbContext.SaveChangesAsync();

            return new ServiceResult<KorisnickiNalogDtoLL>();
        }

        public override async Task<PagedList<KorisnickiNalog>> FilterAndPrepare(IQueryable<KorisnickiNalog> result, KorisnickiNalogResourceParameters resourceParameters)
        {
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

        public async Task<KorisnickiNalogDtoLL> Authenticate(string username, string password)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FirstOrDefaultAsync(x => x.Username == username);

            if (korisnickiNalog != null)
            {
                var newHash = GenerateHash(korisnickiNalog.PasswordSalt, password);

                if (newHash == korisnickiNalog.PasswordHash)
                    return _mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog);
            }
            return null;
        }

        public async Task<ServiceResult<KorisnickiNalogDtoLL>> ToggleLock(int id, bool isForLockout, DateTime? until = null)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);

            if (korisnickiNalog == null)
                return new ServiceResult<KorisnickiNalogDtoLL>(HttpStatusCode.NotFound, $"Korisnicki nalog sa ID-em {id} nije pronadjen.");

            korisnickiNalog.LockedOut = isForLockout;
            korisnickiNalog.LockedOutUntil = until;

            await _dbContext.SaveChangesAsync();

            return new ServiceResult<KorisnickiNalogDtoLL>(_mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog));
        }

        public async Task<ServiceResult<KorisnickiNalogDtoLL>> AddInRoles(int id, KorisnickiNalogRolesUpsertDto request)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);

            if (korisnickiNalog == null)
                return new ServiceResult<KorisnickiNalogDtoLL>(HttpStatusCode.NotFound, $"Korisnicki nalog sa ID-em {id} nije pronadjen.");

            foreach (var roleId in request.Roles)
            {
                if (!await _dbContext.Roles.AnyAsync(x => x.Id == roleId))
                    return new ServiceResult<KorisnickiNalogDtoLL>(HttpStatusCode.NotFound, $"Rola sa ID-em {roleId} nije pronadjena");
                if (await _dbContext.RolesKorisnickiNalozi.AnyAsync(x => x.KorisnickiNalogId == korisnickiNalog.Id && x.RoleId == roleId))
                    return new ServiceResult<KorisnickiNalogDtoLL>(HttpStatusCode.BadRequest, $"Korisnik sa ID-em {id} vec poseduje role sa ID-em {roleId}");
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

        public async Task<ServiceResult<KorisnickiNalogDtoLL>> RemoveFromRoles(int id, KorisnickiNalogRolesUpsertDto request)
        {
            var korisnickiNalog = await _dbContext.KorisnickiNalozi.FindAsync(id);

            if (korisnickiNalog == null)
                return new ServiceResult<KorisnickiNalogDtoLL>(HttpStatusCode.NotFound, $"Korisnicki nalog sa ID-em {id} nije pronadjen.");

            foreach (var roleId in request.Roles)
            {
                var roleKorisnickiNalog = await _dbContext.RolesKorisnickiNalozi.FirstOrDefaultAsync(x =>
                    x.RoleId == roleId && korisnickiNalog.Id == x.KorisnickiNalogId);
                if (roleKorisnickiNalog == null)
                {
                    return new ServiceResult<KorisnickiNalogDtoLL>(HttpStatusCode.BadRequest, $"Korisnik sa ID-em {id} ne poseduje role sa ID-em {roleId}");
                }

                await Task.Run(() =>
                {
                    _dbContext.RolesKorisnickiNalozi.Remove(roleKorisnickiNalog);
                });
            }

            await _dbContext.SaveChangesAsync();

            await _dbContext.Entry(korisnickiNalog).Collection(x => x.RolesKorisnickiNalog).LoadAsync();

            return new ServiceResult<KorisnickiNalogDtoLL>(_mapper.Map<KorisnickiNalogDtoLL>(korisnickiNalog));
        }

        private string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        private string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA512");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}