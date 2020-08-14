using HealthCare020.Core.Models;
using HealthCare020.Services.Interfaces;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Healthcare020.OAuth.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IKorisnikService _korisnikService;
        private KorisnickiNalogDtoEL KorisnickiNalog;

        public ProfileService(IKorisnikService korisnikService)
        {
            _korisnikService = korisnikService;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var korisnikId = context.Subject.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            KorisnickiNalog = await GetKorisnickiNalog(int.Parse(korisnikId ?? "0"));

            var claimsToAdd = new List<Claim>
            {
                new Claim("roles", string.Join(", ", KorisnickiNalog.Roles.Select(x => x.Naziv)))
            };

            context.IssuedClaims.AddRange(claimsToAdd);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var korisnikId = context.Subject.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            KorisnickiNalog = await GetKorisnickiNalog(int.Parse(korisnikId ?? "0"));
            context.IsActive = !KorisnickiNalog.LockedOut;
        }

        private async Task<KorisnickiNalogDtoEL> GetKorisnickiNalog(int id)
        {

            var result = await _korisnikService.GetById(id, true);

            if (!result.Succeeded)
                return null;

            return result.Data as KorisnickiNalogDtoEL;
        }
    }
}