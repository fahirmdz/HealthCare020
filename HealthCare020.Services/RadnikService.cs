using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Repository;
using HealthCare020.Services.Exceptions;
using HealthCare020.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare020.Services
{
    public class RadnikService:IRadnikService
    {
        private readonly HealthCare020DbContext _dbContext;
        private readonly ICRUDService<LicniPodaci, LicniPodaciDto,LicniPodaciDtoEagerLoaded, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto> _licniPodaciService;
        private readonly IKorisnikService _korisnikService;
        private readonly IMapper _mapper;

        public RadnikService(HealthCare020DbContext dbContext, 
            ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDtoEagerLoaded, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto> licniPodaciService, 
            IKorisnikService korisnikService, IMapper mapper)
        {
            _dbContext = dbContext;
            _licniPodaciService = licniPodaciService;
            _korisnikService = korisnikService;
            _mapper = mapper;
        }


        public async Task<Radnik> Insert(RadnikUpsertDto radnikDto)
        {
            if (!await _dbContext.StacionarnaOdeljenja.AnyAsync(x => x.Id == radnikDto.StacionarnoOdeljenjeId))
                throw new NotFoundException($"Stacionarno odeljenje sa ID-em {radnikDto.StacionarnoOdeljenjeId} nije pronadjeno");

            var licniPodaciResult = await _licniPodaciService.Insert(radnikDto.LicniPodaci);

            var korisnickiNalogResult = await _korisnikService.Insert(radnikDto.KorisnickiNalog);

            var radnik = _mapper.Map<Radnik>(radnikDto);
            radnik.KorisnickiNalogId = korisnickiNalogResult.Id;
            radnik.LicniPodaciId = licniPodaciResult.Id;


            await _dbContext.AddAsync(radnik);
            await _dbContext.SaveChangesAsync();

            return radnik;
        }

        public Radnik Update(int id, RadnikUpsertDto radnikDto)
        {
            if (!_dbContext.StacionarnaOdeljenja.Any(x => x.Id == radnikDto.StacionarnoOdeljenjeId))
                throw new NotFoundException($"Stacionarno odeljenje sa ID-em {radnikDto.StacionarnoOdeljenjeId} nije pronadjeno");

            var entity = _dbContext.Radnici
                .Include(x => x.KorisnickiNalog)
                .Include(x => x.LicniPodaci)
                .FirstOrDefault(x => x.Id == id);

            if (entity == null)
                throw new NotFoundException($"Radnik sa ID-em {id} nije pronadjen");

            _korisnikService.Update(entity.KorisnickiNalogId, radnikDto.KorisnickiNalog);
            _licniPodaciService.Update(entity.LicniPodaciId, radnikDto.LicniPodaci);
            entity.StacionarnoOdeljenjeId = radnikDto.StacionarnoOdeljenjeId;

            _dbContext.Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Radnici.Find(id);

            if (entity == null)
                throw new NotFoundException($"Radnik sa ID-em {id} nije pronadjen");

            _licniPodaciService.Delete(entity.LicniPodaciId);
            _korisnikService.Delete(entity.KorisnickiNalogId);
            _dbContext.Remove(entity);
        }
    }
}