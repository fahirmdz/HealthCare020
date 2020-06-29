using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Enums;
using HealthCare020.Repository;
using Microsoft.EntityFrameworkCore;

namespace HealthCare020.Services.Services
{
    public class AuthService : IAuthService
    {
        private IHttpContextAccessor _httpContextAccessor;
        protected readonly HealthCare020DbContext _dbContext;

        public AuthService(IHttpContextAccessor httpContextAccessor, HealthCare020DbContext dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }

        public async Task<bool> IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.User?.Identity?.IsAuthenticated ?? false;
        }

        public async Task<bool> CurrentUserIsInRoleAsync(RoleType role)
        {
            return GetClaim("roles").ToLower().Contains(role.ToDescriptionString().ToLower());
        }

        public bool UserIsPacijent() => GetClaim("roles").ToLower().Trim() == RoleType.Pacijent.ToDescriptionString().ToLower();

        public bool UserIsDoktor() =>
            string.Equals(GetClaim("roles").Split(",")?[0]??string.Empty, RoleType.Doktor.ToDescriptionString(), StringComparison.CurrentCultureIgnoreCase);

        public RoleType? TypeOfCurrentUser()
        {
            if (IsAuthenticated().Result)
            {
                var roles = GetClaim("roles").Trim().Split(",");
                if (roles.Any())
                    return RoleTypeManager.RoleTypeFromString(roles[0]);
            }

            return null;
        }

        public async Task<KorisnickiNalog> LoggedInUser()
        {
            var subClaim = GetClaim("sub");

            if (string.IsNullOrWhiteSpace(subClaim))
                return null;

            int.TryParse(subClaim, out int userId);

            return await _dbContext.KorisnickiNalozi.FindAsync(userId);
        }

        public async Task<Pacijent> GetCurrentLoggedInPacijent()
        {
            var user = await LoggedInUser();
            if (user == null)
                return null;

            return await _dbContext.Pacijenti.FirstOrDefaultAsync(x => x.KorisnickiNalogId == user.Id);
        }

        public async Task<Doktor> GetCurrentLoggedInDoktor()
        {
            var user = await LoggedInUser();
            if (user == null)
                return null;

            return await _dbContext.Doktori.FirstOrDefaultAsync(x => x.Radnik.KorisnickiNalogId == user.Id);
        }

        private string GetClaim(string type) =>
            _httpContextAccessor.HttpContext.User?.Claims.FirstOrDefault(x => x.Type == type)?.Value??string.Empty;
    }
}