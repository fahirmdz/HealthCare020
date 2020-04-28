﻿using System;
using System.Linq;
using System.Threading.Tasks;
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

namespace HealthCare020.Services
{
    public class DnevniIzvestajService:BaseCRUDService<DnevniIzvestajDtoLL,DnevniIzvestajDtoEL,DnevniIzvestajResourceParameters,DnevniIzvestaj,DnevniIzvestajUpsertDto,DnevniIzvestajUpsertDto>
    {
        public DnevniIzvestajService(IMapper mapper,
            HealthCare020DbContext dbContext, 
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor)
            : base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor)
        {
        }

        public override IQueryable<DnevniIzvestaj> GetWithEagerLoad(int? id = null)
        {
            var result = _dbContext.DnevniIzvestaji
                .Include(x => x.Pacijent)
                .ThenInclude(x => x.LicniPodaci)
                .Include(x => x.Doktor)
                .ThenInclude(x => x.Radnik)
                .ThenInclude(x => x.LicniPodaci)
                .Include(x => x.ZdravstvenoStanje)
                .AsQueryable();

            if (id.HasValue)
                result = result.Where(x => x.Id == id);

            return result;
        }

        public override async Task<DnevniIzvestajDtoLL> Insert(DnevniIzvestajUpsertDto dtoForCreation)
        {
            var loggedInDoktor = await GetLoggedInDoktor();

            await ValidateRelationshipsExist(dtoForCreation);

            var newDnevniIzvestaj = _mapper.Map<DnevniIzvestaj>(dtoForCreation);
            newDnevniIzvestaj.DatumVreme=DateTime.Now;
            newDnevniIzvestaj.DoktorId = loggedInDoktor.Id;

            await _dbContext.AddAsync(newDnevniIzvestaj);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<DnevniIzvestajDtoLL>(newDnevniIzvestaj);
        }

        public override async Task<DnevniIzvestajDtoLL> Update(int id, DnevniIzvestajUpsertDto dtoForUpdate)
        {
            var loggedInDoktor = await GetLoggedInDoktor();

            var dnevniIzvestajFromDb = await _dbContext.DnevniIzvestaji.FindAsync(id);

            if(dnevniIzvestajFromDb==null)
                throw new NotFoundException($"Dnevni izvestaj sa ID-em {id} nije pronadjen.");

            await ValidateRelationshipsExist(dtoForUpdate);

            _mapper.Map(dtoForUpdate, dnevniIzvestajFromDb);

            _dbContext.Update(dnevniIzvestajFromDb);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<DnevniIzvestajDtoLL>(dnevniIzvestajFromDb);
        }

        public override async Task<PagedList<DnevniIzvestaj>> FilterAndPrepare(IQueryable<DnevniIzvestaj> result, DnevniIzvestajResourceParameters resourceParameters)
        {
            if (!string.IsNullOrWhiteSpace(resourceParameters.Opis))
            {
                result = result.Where(x => x.OpisStanja.ToLower().Contains(resourceParameters.Opis.ToLower()));
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

            if (!string.IsNullOrWhiteSpace(resourceParameters.DoktorIme) && await result.AnyAsync())
            {
                result = result.Where(x =>
                    x.Doktor.Radnik.LicniPodaci.Ime.ToLower().StartsWith(resourceParameters.DoktorIme.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(resourceParameters.DoktorPrezime) && await result.AnyAsync())
            {
                result = result.Where(x =>
                    x.Doktor.Radnik.LicniPodaci.Prezime.ToLower().StartsWith(resourceParameters.DoktorPrezime.ToLower()));
            }
            if (resourceParameters.DoktorId.HasValue && await result.AnyAsync())
            {
                result = result.Where(x => x.DoktorId == resourceParameters.DoktorId);
            }

            if (!string.IsNullOrWhiteSpace(resourceParameters.Datum) && await result.AnyAsync())
            {
                if (DateTime.TryParse(resourceParameters.Datum, out DateTime parsedDateTime))
                    result = result.Where(x => x.DatumVreme.Date == parsedDateTime.Date);
            }

            if (!string.IsNullOrWhiteSpace(resourceParameters.ZdravstvenoStanje) && await result.AnyAsync())
            {
                result = result.Where(x =>
                    x.ZdravstvenoStanje.Opis.ToLower().StartsWith(resourceParameters.ZdravstvenoStanje.ToLower()));
            }

            return await base.FilterAndPrepare(result, resourceParameters);
        }

        private async Task ValidateRelationshipsExist(DnevniIzvestajUpsertDto dto)
        {
            if(!await _dbContext.Pacijenti.AnyAsync(x=>x.Id==dto.PacijentId))
                throw new NotFoundException($"Pacijent sa ID-em {dto.PacijentId} nije pronadjen.");

            if(!await _dbContext.ZdravstvenaStanja.AnyAsync(x=>x.Id==dto.ZdravstvenoStanjeId))
                throw new NotFoundException($"Zdravstveno stanje sa ID-em {dto.PacijentId} nije pronadjeno.");
        }

        private async Task<Doktor> GetLoggedInDoktor()
        {
            var loggedInUserId = _httpContextAccessor.HttpContext.GetUserIdFromIdentityClaim();

            var loggedInUser = await _dbContext.KorisnickiNalozi.FindAsync(loggedInUserId);

            if (loggedInUser == null)
                throw new UnauthorizedException("Unauthorized access");

            var loggedInDoktor = await _dbContext.Doktori
                .FirstOrDefaultAsync(x => x.Radnik.KorisnickiNalogId == loggedInUserId);

            if (loggedInDoktor == null)
                throw new ForbiddenException($"Samo doktori mogu kreirati dnevne izvestaje.");

            return loggedInDoktor;
        }
    }
}