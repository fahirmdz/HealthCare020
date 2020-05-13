using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HealthCare020.Core.ServiceModels;

namespace HealthCare020.Services
{
    public class CustomIzvestajService : BaseCRUDService<CustomIzvestajDtoLL, CustomIzvestajDtoEL, CustomIzvestajResourceParameters, CustomIzvestaj, CustomIzvestajUpsertDto, CustomIzvestajUpsertDto>
    {
        public CustomIzvestajService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor)
            : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor)
        {
        }

        public override IQueryable<CustomIzvestaj> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.CustomIzvestaji
                .Include(x => x.Pacijent)
                .ThenInclude(x => x.LicniPodaci)
                .Include(x => x.MedicinskiTehnicar)
                .ThenInclude(x => x.Radnik)
                .ThenInclude(x => x.LicniPodaci)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<ServiceResult<CustomIzvestajDtoLL>> Insert(CustomIzvestajUpsertDto dtoForCreation)
        {
            var loggedInMedicinskiTehnicar = await GetLoggedInMedicinskiTehnicar();

            if (loggedInMedicinskiTehnicar == null)
            {
                return new ServiceResult<CustomIzvestajDtoLL>(HttpStatusCode.Forbidden,$"Samo medicinski tehnicari mogu kreirati custom izvestaje.");
            }

            if (!await _dbContext.Pacijenti.AnyAsync(x => x.Id == dtoForCreation.PacijentId))
               return new ServiceResult<CustomIzvestajDtoLL>(HttpStatusCode.NotFound,$"Pacijent sa ID-em {dtoForCreation.PacijentId} nije pronadjen.");

            var newCustomIzvestaj = _mapper.Map<CustomIzvestaj>(dtoForCreation);

            newCustomIzvestaj.DatumVreme = DateTime.Now;
            newCustomIzvestaj.MedicinskiTehnicarId = loggedInMedicinskiTehnicar.Id;

            await _dbContext.AddAsync(newCustomIzvestaj);
            await _dbContext.SaveChangesAsync();

            return new ServiceResult<CustomIzvestajDtoLL>(_mapper.Map<CustomIzvestajDtoLL>(newCustomIzvestaj));
        }

        public override async Task<ServiceResult<CustomIzvestajDtoLL>> Update(int id, CustomIzvestajUpsertDto dtoForUpdate)
        {
            var loggedInMedicinskiTehnicar = await GetLoggedInMedicinskiTehnicar();

            if (loggedInMedicinskiTehnicar == null)
            {
                return new ServiceResult<CustomIzvestajDtoLL>(HttpStatusCode.Forbidden,$"Samo medicinski tehnicari mogu kreirati custom izvestaje.");
            }

            var customIzvestajFromDb = await _dbContext.CustomIzvestaji.FindAsync(id);

            if (customIzvestajFromDb == null)
               return new ServiceResult<CustomIzvestajDtoLL>(HttpStatusCode.NotFound,$"Custom izvestaj sa ID-em {id} nije pronadjen.");

            if (!await _dbContext.Pacijenti.AnyAsync(x => x.Id == dtoForUpdate.PacijentId))
               return new ServiceResult<CustomIzvestajDtoLL>(HttpStatusCode.NotFound,$"Pacijent sa ID-em {dtoForUpdate.PacijentId} nije pronadjen.");

            _mapper.Map(dtoForUpdate, customIzvestajFromDb);

            _dbContext.Update(customIzvestajFromDb);
            await _dbContext.SaveChangesAsync();

            return new ServiceResult<CustomIzvestajDtoLL>(_mapper.Map<CustomIzvestajDtoLL>(customIzvestajFromDb));
        }

        public override async Task<PagedList<CustomIzvestaj>> FilterAndPrepare(IQueryable<CustomIzvestaj> result, CustomIzvestajResourceParameters resourceParameters)
        {
            if (!string.IsNullOrWhiteSpace(resourceParameters.MedicinskiTehnicarIme) && await result.AnyAsync())
            {
                result = result.Where(x =>
                    x.MedicinskiTehnicar.Radnik.LicniPodaci.Ime.ToLower()
                        .StartsWith(resourceParameters.MedicinskiTehnicarIme.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(resourceParameters.MedicinskiTehnicarPrezime) && await result.AnyAsync())
            {
                result = result.Where(x =>
                    x.MedicinskiTehnicar.Radnik.LicniPodaci.Prezime.ToLower()
                        .StartsWith(resourceParameters.MedicinskiTehnicarPrezime.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(resourceParameters.PacijentIme) && await result.AnyAsync())
            {
                result = result.Where(x =>
                    x.Pacijent.LicniPodaci.Ime.ToLower()
                        .StartsWith(resourceParameters.PacijentIme.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(resourceParameters.PacijentPrezime) && await result.AnyAsync())
            {
                result = result.Where(x =>
                    x.Pacijent.LicniPodaci.Prezime.ToLower()
                        .StartsWith(resourceParameters.PacijentPrezime.ToLower()));
            }

            if (resourceParameters.PacijentId.HasValue && await result.AnyAsync())
            {
                result = result.Where(x => x.PacijentId == resourceParameters.PacijentId);
            }

            if (resourceParameters.MedicinskiTehnicarId.HasValue && await result.AnyAsync())
            {
                result = result.Where(x => x.MedicinskiTehnicarId == resourceParameters.MedicinskiTehnicarId);
            }

            if (resourceParameters.MedicinskiTehnicarId.HasValue && await result.AnyAsync())
            {
                result = result.Where(x => x.MedicinskiTehnicarId == resourceParameters.MedicinskiTehnicarId);
            }

            if (!string.IsNullOrWhiteSpace(resourceParameters.Datum) && await result.AnyAsync())
            {
                if (DateTime.TryParse(resourceParameters.Datum, out DateTime parsedDateTime))
                    result = result.Where(x => x.DatumVreme.Date == parsedDateTime.Date);
            }

            return await base.FilterAndPrepare(result, resourceParameters);
        }

        private async Task<MedicinskiTehnicar> GetLoggedInMedicinskiTehnicar()
        {
            var loggedInUserId = _httpContextAccessor.HttpContext.GetUserIdFromIdentityClaim();

            var loggedInUser = await _dbContext.KorisnickiNalozi.FindAsync(loggedInUserId);

            if (loggedInUser == null)
                throw new UnauthorizedException("Unauthorized access");

            var loggedInMedicinskiTehnicar = await _dbContext.MedicinskiTehnicari
                .FirstOrDefaultAsync(x => x.Radnik.KorisnickiNalogId == loggedInUserId);

            return loggedInMedicinskiTehnicar;
        }
    }
}