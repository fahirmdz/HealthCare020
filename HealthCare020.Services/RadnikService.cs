using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Core.ServiceModels;
using HealthCare020.Repository;
using HealthCare020.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class RadnikService : IRadnikService
    {
        private readonly HealthCare020DbContext _dbContext;
        private readonly ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto> _licniPodaciService;
        private readonly IKorisnikService _korisnikService;
        private readonly IMapper _mapper;

        public RadnikService(HealthCare020DbContext dbContext,
            ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto> licniPodaciService,
            IKorisnikService korisnikService, IMapper mapper)
        {
            _dbContext = dbContext;
            _licniPodaciService = licniPodaciService;
            _korisnikService = korisnikService;
            _mapper = mapper;
        }

        public async Task<ServiceResult> Insert(RadnikUpsertDto radnikDto)
        {
            if (!await _dbContext.StacionarnaOdeljenja.AnyAsync(x => x.Id == radnikDto.StacionarnoOdeljenjeId))
                return ServiceResult.NotFound($"Stacionarno odeljenje sa ID-em {radnikDto.StacionarnoOdeljenjeId} nije pronadjeno");

            var licniPodaciResultTemp = await _licniPodaciService.Insert(radnikDto.LicniPodaci);
            if (!licniPodaciResultTemp.Succeeded)
                return ServiceResult.WithStatusCode(licniPodaciResultTemp.StatusCode, licniPodaciResultTemp.Message);
            var licniPodaciResult = licniPodaciResultTemp.Data as LicniPodaciDto;

            var korisnickiNalogResultTemp = await _korisnikService.Insert(radnikDto.KorisnickiNalog);
            if (!korisnickiNalogResultTemp.Succeeded)
                return ServiceResult.WithStatusCode(korisnickiNalogResultTemp.StatusCode, korisnickiNalogResultTemp.Message);
            var korisnickiNalogResult = korisnickiNalogResultTemp.Data as KorisnickiNalogDtoLL;

            var radnik = new Radnik
            {
                KorisnickiNalogId = korisnickiNalogResult.Id,
                LicniPodaciId = licniPodaciResult.Id,
                StacionarnoOdeljenjeId = radnikDto.StacionarnoOdeljenjeId
            };

            await _dbContext.AddAsync(radnik);
            await _dbContext.SaveChangesAsync();

            return ServiceResult.OK(radnik);
        }

        public async Task<ServiceResult> Update(int id, RadnikUpsertDto radnikDto)
        {
            if (!_dbContext.StacionarnaOdeljenja.Any(x => x.Id == radnikDto.StacionarnoOdeljenjeId))
                return ServiceResult.NotFound($"Stacionarno odeljenje sa ID-em {radnikDto.StacionarnoOdeljenjeId} nije pronadjeno");

            var entity = await _dbContext.Radnici
                .Include(x => x.KorisnickiNalog)
                .Include(x => x.LicniPodaci)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return ServiceResult.NotFound($"Radnik sa ID-em {id} nije pronadjen");

            await _korisnikService.Update(entity.KorisnickiNalogId, radnikDto.KorisnickiNalog);
            await _licniPodaciService.Update(entity.LicniPodaciId, radnikDto.LicniPodaci);

            await Task.Run(() =>
            {
                entity.StacionarnoOdeljenjeId = radnikDto.StacionarnoOdeljenjeId;

                _dbContext.Update(entity);
            });

            await _dbContext.SaveChangesAsync();

            return ServiceResult.OK(entity);
        }

        public async Task<ServiceResult> Delete(int id)
        {
            var entity = await _dbContext.Radnici.FindAsync(id);

            if (entity == null)
                return ServiceResult.NotFound($"Radnik sa ID-em {id} nije pronadjen");

            await _licniPodaciService.Delete(entity.LicniPodaciId);
            await _korisnikService.Delete(entity.KorisnickiNalogId);

            await Task.Run(() => { _dbContext.Remove(entity); });

            return ServiceResult.NoContent();
        }
    }
}