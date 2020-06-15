using System.Threading.Tasks;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Enums;

namespace HealthCare020.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> IsAuthenticated();
        public Task<bool> CurrentUserIsInRoleAsync(RoleType role);
        public RoleType? TypeOfCurrentUser();
        public Task<KorisnickiNalog> LoggedInUser();

    }
}