using System;
using System.Linq;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Enums;
using HealthCare020.Repository;

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

        public async Task<KorisnickiNalog> LoggedInUser()
        {
            var subClaim = GetClaim("sub");

            if (string.IsNullOrWhiteSpace(subClaim))
                return null;

            int.TryParse(subClaim, out int userId);

            return await _dbContext.KorisnickiNalozi.FindAsync(userId);
        }

        private string GetClaim(string type) =>
            _httpContextAccessor.HttpContext.User?.Claims.FirstOrDefault(x => x.Type == type)?.Value??string.Empty;
    }
}