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
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class RadnikService : BaseCRUDService<RadnikDtoEagerLoaded, RadnikResourceParameters, Radnik, RadnikUpsertDto, RadnikUpsertDto>
    {
        private readonly ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto> _licniPodaciService;
        private readonly IKorisnikService _korisnikService;

        public RadnikService(IMapper mapper, HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto> licniPodaciService,
            IKorisnikService korisnikService) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService)
        {
            _licniPodaciService = licniPodaciService;
            _korisnikService = korisnikService;
        }

        public override IQueryable<Radnik> GetWithEagerLoad(int? id=null)
        {
            var result = _dbContext.Radnici
                .Include(x => x.KorisnickiNalog)
                .Include(x => x.LicniPodaci)
                .ThenInclude(x=>x.Grad)
                .Include(x => x.StacionarnoOdeljenje)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<RadnikDtoEagerLoaded> Insert(RadnikUpsertDto request)
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

            return _mapper.Map<RadnikDtoEagerLoaded>(entity);
        }

        public override RadnikDtoEagerLoaded Update(int id, RadnikUpsertDto request)
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

            return _mapper.Map<RadnikDtoEagerLoaded>(entity);
        }

        public override RadnikDtoEagerLoaded Delete(int id)
        {
            var entity = _dbContext.Radnici.Find(id);

            if (entity == null)
                throw new NotFoundException($"Radnik sa ID-em {id} nije pronadjen");

            var model = _mapper.Map<RadnikDtoEagerLoaded>(entity);

            _licniPodaciService.Delete(entity.LicniPodaciId);
            _korisnikService.Delete(entity.KorisnickiNalogId);
            _dbContext.Remove(entity);

            return model;
        }

        public override async Task<IEnumerable> FilterAndPrepare(IQueryable<Radnik> result, RadnikResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;

            if (!string.IsNullOrEmpty(resourceParameters.Ime))
                result = result.Where(x => x.LicniPodaci.Ime.StartsWith(resourceParameters.Ime));

            if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.Prezime))
                result = result.Where(x => x.LicniPodaci.Prezime.StartsWith(resourceParameters.Prezime));

            if (await result.AnyAsync() && !string.IsNullOrEmpty(resourceParameters.Username))
                result = result.Where(x => x.KorisnickiNalog.Username.StartsWith(resourceParameters.Username));

            if (resourceParameters.EagerLoaded)
            {
                PropertyCheck<RadnikDtoEagerLoaded>(resourceParameters.Fields);

                return result.Select(x =>
                    _mapper.Map<RadnikDtoEagerLoaded>(x).Map(_mapper, x.KorisnickiNalog).Map(_mapper, x.LicniPodaci)
                        .Map(_mapper, x.StacionarnoOdeljenje).ShapeData(resourceParameters.Fields));
            }

            return await result.Select(x => _mapper.Map<RadnikDtoLazyLoaded>(x)).ToListAsync();
        }

        public override async Task<ExpandoObject> FilterAndPrepare(Radnik entity, RadnikResourceParameters resourceParameters)
        {
            if (resourceParameters.EagerLoaded)
            {
                PropertyCheck<RadnikDtoEagerLoaded>(resourceParameters.Fields);

                return  _mapper.Map<RadnikDtoEagerLoaded>(entity).Map(_mapper, entity.KorisnickiNalog).Map(_mapper, entity.LicniPodaci)
                        .Map(_mapper, entity.StacionarnoOdeljenje).ShapeData(resourceParameters.Fields);
            }

            return _mapper.Map<RadnikDtoLazyLoaded>(entity).ShapeData(resourceParameters.Fields);
        }
    }
}