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
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HealthCare020.Core.Enums;
using HealthCare020.Services.Services;

namespace HealthCare020.Services
{
    public class PacijentService : BaseCRUDService<PacijentDtoLL, PacijentDtoEL, PacijentResourceParameters, Pacijent, PacijentUpsertDto, PacijentUpsertDto>
    {
        private readonly ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters,
            LicniPodaciUpsertDto, LicniPodaciUpsertDto> _licniPodaciService;

        private IAuthService _authService;

        public PacijentService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto> licniPodaciService,
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor)
        {
            _licniPodaciService = licniPodaciService;
            _authService = authService;
        }

        public override IQueryable<Pacijent> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.Set<Pacijent>()
                .Include(x => x.ZdravstvenaKnjizica)
                .ThenInclude(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .ThenInclude(x => x.Drzava)
                .Include(x => x.KorisnickiNalog)
                .AsQueryable();
            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<ServiceResult> Insert(PacijentUpsertDto dtoForCreation)
        {
            var validInput = await ValidUpsertData(dtoForCreation);
            if (!validInput.Succeeded)
                return ServiceResult.WithStatusCode(validInput.StatusCode, validInput.Message);

            var pacijent = new Pacijent
            {
                KorisnickiNalogId =dtoForCreation.KorisnickiNalogId,
                ZdravstvenaKnjizicaId = dtoForCreation.ZdravstvenaKnjizicaId
            };

            await _dbContext.AddAsync(pacijent);
            await _dbContext.SaveChangesAsync();

            return ServiceResult<PacijentDtoLL>.OK(_mapper.Map<PacijentDtoLL>(pacijent));
        }

        public override  async Task<ServiceResult> Update(int id, PacijentUpsertDto dtoForUpdate)
        {
            if(!await _authService.CurrentUserIsInRoleAsync(RoleType.Administrator))
                return ServiceResult.Forbidden($"Samo administrator moze mijenjati zdravstvenu knjizicu i korisnicki nalog pacijenta.");

            var entity = await _dbContext.Set<Pacijent>().FindAsync(id);

            if (entity == null)
                return ServiceResult.NotFound($"Pacijent sa ID-em {id} nije pronadjen.");

            if (entity.ZdravstvenaKnjizicaId != dtoForUpdate.ZdravstvenaKnjizicaId)
            {
                if (!await _dbContext.ZdravstvenaKnjizica.AnyAsync(x => x.Id == dtoForUpdate.ZdravstvenaKnjizicaId))
                    return ServiceResult.BadRequest($"Zdravstvena knjizica sa ID-em {dtoForUpdate.ZdravstvenaKnjizicaId} nije pronadjena.");

                if (await _dbContext.Pacijenti.AnyAsync(x => x.ZdravstvenaKnjizicaId == dtoForUpdate.ZdravstvenaKnjizicaId))
                    return ServiceResult.BadRequest($"Vec postoji pacijent sa zdravstvenom knjizicom broj {dtoForUpdate.ZdravstvenaKnjizicaId}");

                entity.ZdravstvenaKnjizicaId = dtoForUpdate.ZdravstvenaKnjizicaId;
            }

            if (entity.KorisnickiNalogId != dtoForUpdate.KorisnickiNalogId)
            {
                if (await _dbContext.Pacijenti.AnyAsync(x => x.ZdravstvenaKnjizicaId == dtoForUpdate.ZdravstvenaKnjizicaId))
                    return ServiceResult.BadRequest($"Vec postoji pacijent koji koristi korisnicki nalog sa ID-em {dtoForUpdate.KorisnickiNalogId}");

                if (!await _dbContext.KorisnickiNalozi.AnyAsync(x => x.Id == dtoForUpdate.KorisnickiNalogId))
                    return ServiceResult.BadRequest($"Korisnicki nalog sa ID-em {dtoForUpdate.KorisnickiNalogId} nije pronadjen.");

                entity.ZdravstvenaKnjizicaId = dtoForUpdate.ZdravstvenaKnjizicaId;
            }

            await _dbContext.SaveChangesAsync();

            return new ServiceResult<PacijentDtoLL>(_mapper.Map<PacijentDtoLL>(entity));
        }

        public override async Task<PagedList<Pacijent>> FilterAndPrepare(IQueryable<Pacijent> result, PacijentResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;


            if (!string.IsNullOrWhiteSpace(resourceParameters.Ime))
                result = result.Where(x => x.ZdravstvenaKnjizica.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.Ime.ToLower()));

            if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.Prezime))
                result = result.Where(x =>
                    x.ZdravstvenaKnjizica.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.Prezime.ToLower()));

            if (await result.AnyAsync() && !string.IsNullOrWhiteSpace(resourceParameters.Username))
                result = result.Where(x =>
                    x.KorisnickiNalog.Username.ToLower().StartsWith(resourceParameters.Username.ToLower()));

            if (await result.AnyAsync() && resourceParameters.ZdravstvenaKnjizicaId.HasValue)
                result = result.Where(x => x.ZdravstvenaKnjizicaId == resourceParameters.ZdravstvenaKnjizicaId);


            return await base.FilterAndPrepare(result, resourceParameters);
        }

        private async Task<(bool Succeeded, HttpStatusCode StatusCode, string Message)> ValidUpsertData(PacijentUpsertDto dto)
        {
            if (!await _dbContext.KorisnickiNalozi.AnyAsync(x => x.Id == dto.KorisnickiNalogId))
                return (false, HttpStatusCode.BadRequest, $"Korisnicki nalog sa ID-em {dto.KorisnickiNalogId} nije pronadjen.");

            if (await _dbContext.Pacijenti.AnyAsync(x => x.ZdravstvenaKnjizicaId == dto.ZdravstvenaKnjizicaId))
                return (false, HttpStatusCode.BadRequest,
                    $"Vec postoji pacijent sa zdravstvenom knjizicom broj {dto.ZdravstvenaKnjizicaId}");

            if (await _dbContext.Pacijenti.AnyAsync(x => x.ZdravstvenaKnjizicaId == dto.ZdravstvenaKnjizicaId))
                return (false, HttpStatusCode.BadRequest,
                    $"Vec postoji pacijent koji koristi korisnicki nalog sa ID-em {dto.KorisnickiNalogId}");

            if (!await _dbContext.ZdravstvenaKnjizica.AnyAsync(x => x.Id == dto.ZdravstvenaKnjizicaId))
                return (false, HttpStatusCode.BadRequest,
                    $"Zdravstvena knjizica sa ID-em {dto.ZdravstvenaKnjizicaId} nije pronadjena.");

            return (true, HttpStatusCode.OK, String.Empty);
        }
    }
}