using System;
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
using System.Linq;
using System.Threading.Tasks;
using HealthCare020.Core.Enums;

namespace HealthCare020.Services
{
    public class RadnikPrijemService : BaseCRUDService<RadnikPrijemDtoLL, RadnikPrijemDtoEL, RadnikPrijemResourceParameters, RadnikPrijem, RadnikPrijemUpsertDto, RadnikPrijemUpsertDto>
    {
        private readonly IRadnikService _radnikService;
        private readonly IKorisnikService _korisnikService;

        public RadnikPrijemService(IMapper mapper, HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IRadnikService radnikService,
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService, 
            IKorisnikService korisnikService) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor, authService)
        {
            _radnikService = radnikService;
            _korisnikService = korisnikService;
        }

        public override IQueryable<RadnikPrijem> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.RadniciPrijem
                .Include(x => x.Radnik)
                .ThenInclude(x => x.KorisnickiNalog)
                .Include(x => x.Radnik)
                .ThenInclude(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .Include(x => x.Radnik)
                .ThenInclude(x => x.StacionarnoOdeljenje)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<ServiceResult> Insert(RadnikPrijemUpsertDto request)
        {
            var radnikInsertResult = await _radnikService.Insert(request);
            if (!radnikInsertResult.Succeeded)
                return ServiceResult.WithStatusCode(radnikInsertResult.StatusCode, radnikInsertResult.Message);
            var radnik = (radnikInsertResult as ServiceResult<Radnik>).Data;
            if(radnik==null)
                throw new NullReferenceException();

            var rolesAddResult = await _korisnikService.AddInRoles(radnik.KorisnickiNalogId,
                new KorisnickiNalogRolesUpsertDto {RoleId = RoleType.RadnikPrijem.ToInt()});
            if(!rolesAddResult.Succeeded)
                return ServiceResult.WithStatusCode(rolesAddResult.StatusCode,rolesAddResult.Message);

            var entity = new RadnikPrijem { RadnikId = radnik.Id };

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return new ServiceResult<RadnikPrijemDtoLL>(_mapper.Map<RadnikPrijemDtoLL>(entity));
        }

        public override async Task<ServiceResult> Update(int id, RadnikPrijemUpsertDto dtoForUpdate)
        {
            var radnikPrijemFromDb = await _dbContext.RadniciPrijem
                .Include(x => x.Radnik)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (radnikPrijemFromDb == null)
                return ServiceResult.NotFound($"Radnik sa ID-em {id} nije pronadjen");

            _mapper.Map(dtoForUpdate, radnikPrijemFromDb.Radnik);
            var radnikUpdated = await _radnikService.Update(radnikPrijemFromDb.RadnikId, dtoForUpdate);

            return new ServiceResult<RadnikPrijemDtoLL>(_mapper.Map<RadnikPrijemDtoLL>(radnikPrijemFromDb));
        }

        public override async Task<ServiceResult> Delete(int id)
        {
            var entity = await _dbContext.RadniciPrijem.FindAsync(id);
            if (entity == null)
                return ServiceResult.NotFound($"RadnikPrijem sa ID-em {id} nije pronadjen.");
            await Task.Run(() =>
            {
                _radnikService.Delete(id);

                _dbContext.Remove(entity);
            });

            await _dbContext.SaveChangesAsync();
            return new ServiceResult<RadnikPrijemDtoLL>();
        }

        public override async Task<PagedList<RadnikPrijem>> FilterAndPrepare(IQueryable<RadnikPrijem> result, RadnikPrijemResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (resourceParameters != null)
            {
                if (!string.IsNullOrEmpty(resourceParameters.Ime))
                    result = result.Where(x =>
                        x.Radnik.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.Ime.ToLower()));

                if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.Prezime))
                    result = result.Where(x =>
                        x.Radnik.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.Prezime.ToLower()));

                if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.Username))
                    result = result.Where(x =>
                        x.Radnik.KorisnickiNalog.Username.ToLower().StartsWith(resourceParameters.Username.ToLower()));

                result = result.Include(x => x.Radnik.LicniPodaci);
            }

            return await base.FilterAndPrepare(result, resourceParameters);
        }
    }
}