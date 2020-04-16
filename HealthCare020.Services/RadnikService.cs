using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.Services
{
    public class RadnikService : BaseCRUDService<RadnikDto, RadnikResourceParameters, Radnik, RadnikUpsertDto, RadnikUpsertDto>
    {
        private readonly ICRUDService<LicniPodaci,LicniPodaciDto,LicniPodaciResourceParameters,LicniPodaciUpsertDto,LicniPodaciUpsertDto> _licniPodaciService;
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

        public override async Task<IList<RadnikDto>> Get(RadnikResourceParameters search)
        {
            var result = _dbContext.Radnici
                .Include(x => x.LicniPodaci)
                .Include(x => x.KorisnickiNalog)
                .Include(x=>x.StacionarnoOdeljenje)
                .AsQueryable();

            if (await result.AnyAsync())
                result = await SearchFilter(result, search);

            if (await result.AnyAsync())
                return await result.Select(x => _mapper.Map<RadnikDto>(x)).ToListAsync();

            return new List<RadnikDto>();
        }

        public override async Task<RadnikDto> Insert(RadnikUpsertDto request)
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

            return _mapper.Map<RadnikDto>(entity);
        }

        public override RadnikDto Update(int id, RadnikUpsertDto request)
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

            return _mapper.Map<RadnikDto>(entity);
        }

        public override RadnikDto Delete(int id)
        {
            var entity = _dbContext.Radnici.Find(id);

            if (entity == null)
                throw new NotFoundException($"Radnik sa ID-em {id} nije pronadjen");

            var model = _mapper.Map<RadnikDto>(entity);

            _licniPodaciService.Delete(entity.LicniPodaciId);
            _korisnikService.Delete(entity.KorisnickiNalogId);
            _dbContext.Remove(entity);

            return model;
        }

        private async Task<IQueryable<Radnik>> SearchFilter(IQueryable<Radnik> result, RadnikResourceParameters search)
        {
            if (!await result.AnyAsync())
                return null;

            if (!string.IsNullOrEmpty(search.Ime))
                result = result.Where(x => x.LicniPodaci.Ime.StartsWith(search.Ime));

            if (await result.AnyAsync() && !string.IsNullOrEmpty(search.Prezime))
                result = result.Where(x => x.LicniPodaci.Prezime.StartsWith(search.Prezime));

            if (await result.AnyAsync() && !string.IsNullOrEmpty(search.Username))
                result = result.Where(x => x.KorisnickiNalog.Username.StartsWith(search.Username));

            return result;
        }

        
    }
}