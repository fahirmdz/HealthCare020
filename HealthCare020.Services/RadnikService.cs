using System;
using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Helpers;
using HealthCare020.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class RadnikService : BaseCRUDService<RadnikDtoLazyLoaded,RadnikDtoEagerLoaded, RadnikResourceParameters, Radnik, RadnikUpsertDto, RadnikUpsertDto>
    {
        private readonly ICRUDService<LicniPodaci, LicniPodaciDto,LicniPodaciDtoEagerLoaded, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto> _licniPodaciService;
        private readonly IKorisnikService _korisnikService;

        public RadnikService(IMapper mapper, HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IKorisnikService korisnikService, ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDtoEagerLoaded, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto> licniPodaciService) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService)
        {
            _korisnikService = korisnikService;
            _licniPodaciService = licniPodaciService;
        }

        public override IQueryable<Radnik> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.Radnici
                .Include(x => x.KorisnickiNalog)
                .Include(x => x.LicniPodaci)
                .ThenInclude(x => x.Grad)
                .Include(x => x.StacionarnoOdeljenje)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<RadnikDtoLazyLoaded> Insert(RadnikUpsertDto request)
        {
            if (!await _dbContext.StacionarnaOdeljenja.AnyAsync(x => x.Id == request.StacionarnoOdeljenjeId))
                throw new NotFoundException($"Stacionarno odeljenje sa ID-em {request.StacionarnoOdeljenjeId} nije pronadjeno");

            var licniPodaciResult = await _licniPodaciService.Insert(request.LicniPodaci);

            var korisnickiNalogResult = await _korisnikService.Insert(request.KorisnickiNalog);

            var entity = new Radnik
            {
                KorisnickiNalogId = korisnickiNalogResult.Id,
                LicniPodaciId = licniPodaciResult.Id,
                StacionarnoOdeljenjeId = request.StacionarnoOdeljenjeId
            };

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<RadnikDtoLazyLoaded>(entity);
        }

        public override RadnikDtoLazyLoaded Update(int id, RadnikUpsertDto request)
        {
            if (!_dbContext.StacionarnaOdeljenja.Any(x => x.Id == request.StacionarnoOdeljenjeId))
                throw new NotFoundException($"Stacionarno odeljenje sa ID-em {request.StacionarnoOdeljenjeId} nije pronadjeno");

            var entity = _dbContext.Radnici
                .Include(x => x.KorisnickiNalog)
                .Include(x => x.LicniPodaci)
                .FirstOrDefault(x => x.Id == id);

            if (entity == null)
                throw new NotFoundException($"Radnik sa ID-em {id} nije pronadjen");

            _korisnikService.Update(entity.KorisnickiNalogId, request.KorisnickiNalog);
            _licniPodaciService.Update(entity.LicniPodaciId, request.LicniPodaci);
            entity.StacionarnoOdeljenjeId = request.StacionarnoOdeljenjeId;

            _dbContext.Update(entity);
            _dbContext.SaveChanges();

            return _mapper.Map<RadnikDtoLazyLoaded>(entity);
        }

        public override RadnikDtoLazyLoaded Delete(int id)
        {
            var entity = _dbContext.Radnici.Find(id);

            if (entity == null)
                throw new NotFoundException($"Radnik sa ID-em {id} nije pronadjen");

            var model = _mapper.Map<RadnikDtoLazyLoaded>(entity);

            _licniPodaciService.Delete(entity.LicniPodaciId);
            _korisnikService.Delete(entity.KorisnickiNalogId);
            _dbContext.Remove(entity);

            return model;
        }

        public override async Task<PagedList<Radnik>> FilterAndPrepare(IQueryable<Radnik> result, RadnikResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (!string.IsNullOrEmpty(resourceParameters.Ime))
                result = result.Where(x => x.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.Ime.ToLower()));

            if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.Prezime))
                result = result.Where(x => x.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.Prezime.ToLower()));

            if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.Username))
                result = result.Where(x => x.KorisnickiNalog.Username.ToLower().StartsWith(resourceParameters.Username.ToLower()));

            result=result.Include(x => x.LicniPodaci);

            if (resourceParameters.EagerLoaded)
                PropertyCheck<RadnikDtoEagerLoaded>(resourceParameters.Fields);

            var pagedResult = PagedList<Radnik>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

            return pagedResult;
        }

        public override IEnumerable PrepareDataForClient(IEnumerable<Radnik> data, RadnikResourceParameters resourceParameters)
        {
            if (resourceParameters.EagerLoaded)
                return data.Select(x => _mapper.Map<RadnikDtoEagerLoaded>(x).Map(_mapper,x.LicniPodaci).Map(_mapper,x.KorisnickiNalog).Map(_mapper,x.StacionarnoOdeljenje));
            return data.Select(x => _mapper.Map<RadnikDtoLazyLoaded>(x));
        }

        public override T PrepareDataForClient<T>(Radnik data, RadnikResourceParameters resourceParameters)
        {
            return _mapper.Map<T>(data).Map(_mapper,data.LicniPodaci).Map(_mapper,data.KorisnickiNalog).Map(_mapper,data.StacionarnoOdeljenje);
        }
    }
}