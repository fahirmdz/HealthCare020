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
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HealthCare020.Services
{
    public class PacijentService : BaseCRUDService<PacijentDtoLL, PacijentDtoEL, PacijentResourceParameters, Pacijent, PacijentUpsertDto, PacijentUpsertDto>
    {
        private readonly ISecurityService _securityService;

        public PacijentService(IMapper mapper,
            HealthCare020DbContext dbContext,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService, ISecurityService securityService) :
            base(mapper, dbContext, propertyMappingService, propertyCheckerService, httpContextAccessor, authService)
        {
            _securityService = securityService;
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
            var zdravstvenaKnjizica = await _dbContext.ZdravstvenaKnjizica
                .Include(x => x.LicniPodaci)
                .FirstOrDefaultAsync(x => x.Id == dtoForCreation.BrojZdravstveneKnjizice);

            var validInput = await ValidateUpsertData(dtoForCreation, zdravstvenaKnjizica);
            if (!validInput.Succeeded)
                return ServiceResult.WithStatusCode(validInput.StatusCode, validInput.Message);

            var korisnickiNalog = _mapper.Map<KorisnickiNalog>(dtoForCreation.KorisnickiNalog);

            if (dtoForCreation.KorisnickiNalog.ConfirmPassword != dtoForCreation.KorisnickiNalog.Password)
            {
                return ServiceResult.BadRequest("Lozinke se ne podudaraju");
            }

            korisnickiNalog.PasswordSalt = _securityService.GenerateSalt();
            korisnickiNalog.PasswordHash = _securityService.GenerateHash(korisnickiNalog.PasswordSalt, dtoForCreation.KorisnickiNalog.Password);

            korisnickiNalog.DateCreated = DateTime.Now;
            korisnickiNalog.LastOnline = DateTime.Now;

            await _dbContext.KorisnickiNalozi.AddAsync(korisnickiNalog);
            await _dbContext.SaveChangesAsync();

            //Adding user to Pacijent role
            var pacijentRole = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Naziv == "Pacijent");
            await _dbContext.RolesKorisnickiNalozi.AddAsync(new RoleKorisnickiNalog
            { KorisnickiNalogId = korisnickiNalog.Id, RoleId = pacijentRole.Id });
            await _dbContext.SaveChangesAsync();

            var pacijent = new Pacijent
            {
                KorisnickiNalogId = korisnickiNalog.Id,
                ZdravstvenaKnjizicaId = zdravstvenaKnjizica.Id
            };

            await _dbContext.AddAsync(pacijent);
            await _dbContext.SaveChangesAsync();

            return ServiceResult<PacijentDtoLL>.OK(_mapper.Map<PacijentDtoLL>(pacijent));
        }

        public override async Task<ServiceResult> Update(int id, PacijentUpsertDto dtoForUpdate)
        {
            var user = await _authService.LoggedInUser();
            if (user == null)
                return ServiceResult.Unauthorized();

            var pacijent = await _dbContext.Pacijenti
                .Include(x => x.KorisnickiNalog)
                .FirstOrDefaultAsync(x => x.KorisnickiNalogId == user.Id);
            if (pacijent == null)
                return ServiceResult.NotFound($"Pacijent povezan sa vasim korisnickim nalogom nije pronadjen.");

            _mapper.Map(dtoForUpdate.KorisnickiNalog, pacijent.KorisnickiNalog);
            await _dbContext.SaveChangesAsync();

            return ServiceResult<PacijentDtoLL>.OK(_mapper.Map<PacijentDtoLL>(pacijent));
        }

        public override async Task<ServiceResult> Delete(int id)
        {
            var user = await _authService.LoggedInUser();
            if (user == null)
                return ServiceResult.Unauthorized();

            var pacijent = await _dbContext.Pacijenti
                .Include(x => x.KorisnickiNalog)
                .FirstOrDefaultAsync(x => x.KorisnickiNalogId == user.Id);
            if (pacijent == null)
                return ServiceResult.NotFound($"Ovaj korisnicki nalog ne koristi ni jedan pacijent.");

            await Task.Run(() =>
            {
                //Brisanje svih podataka vezanih za pacijenta
                var zahtevi = _dbContext.ZahteviZaPregled.Where(x => x.PacijentId == pacijent.Id);
                if (zahtevi.Any())
                    _dbContext.RemoveRange(zahtevi);

                var uputnice = _dbContext.Uputnice.Where(x => x.PacijentId == pacijent.Id);
                if (uputnice.Any())
                    _dbContext.RemoveRange(uputnice);

                var pregledi = _dbContext.Pregledi.Where(x => x.PacijentId == pacijent.Id);
                foreach (var pregled in pregledi)
                {
                    var lekarskoUverenje = _dbContext.LekarskaUverenja.FirstOrDefault(x => x.PregledId == pregled.Id);
                    if (lekarskoUverenje != null)
                        _dbContext.Remove(lekarskoUverenje);
                }

                if (pregledi.Any())
                    _dbContext.RemoveRange(pregledi);

                var rolesKorisnickiNalog =
                    _dbContext.RolesKorisnickiNalozi.Where(x => x.KorisnickiNalogId == pacijent.KorisnickiNalogId);
                if(rolesKorisnickiNalog.Any())
                    _dbContext.RemoveRange(rolesKorisnickiNalog);

                _dbContext.Remove(pacijent.KorisnickiNalog);
                _dbContext.Remove(pacijent);
            });
            await _dbContext.SaveChangesAsync();

            return ServiceResult<PacijentDtoLL>.NoContent();
        }

        public override async Task<PagedList<Pacijent>> FilterAndPrepare(IQueryable<Pacijent> result, PacijentResourceParameters resourceParameters)
        {
            if (!await result.AnyAsync())
                return null;
            result = result.Include(x => x.KorisnickiNalog)
                .ThenInclude(x => x.RolesKorisnickiNalog);

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

        private async Task<(bool Succeeded, HttpStatusCode StatusCode, string Message)> ValidateUpsertData(PacijentUpsertDto dto, ZdravstvenaKnjizica zdravstvenaKnjizica)
        {
            if (zdravstvenaKnjizica == null)
                return (false, HttpStatusCode.BadRequest,
                    $"Zdravstvena knjizica sa ID-em {dto.BrojZdravstveneKnjizice} nije pronadjena.");

            if (await _dbContext.Pacijenti.AnyAsync(x => x.ZdravstvenaKnjizicaId == dto.BrojZdravstveneKnjizice))
                return (false, HttpStatusCode.BadRequest,
                    $"Vec postoji pacijent sa zdravstvenom knjizicom broj {dto.BrojZdravstveneKnjizice}");

            //Provera da li je pacijent stvarni vlasnik zdravstvene knjizice pod navedenim brojem
            if (zdravstvenaKnjizica.LicniPodaci.Ime != dto.Ime ||
                zdravstvenaKnjizica.LicniPodaci.Prezime != dto.Prezime ||
                zdravstvenaKnjizica.LicniPodaci.JMBG != dto.JMBG.Trim())
                return (false, HttpStatusCode.BadRequest, $"Validacija unijetih podataka neuspjesna.");

            return (true, HttpStatusCode.OK, String.Empty);
        }
    }
}