using HealthCare020.Core.Entities;
using HealthCare020.Core.Enums;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> IsAuthenticated();

        Task<bool> CurrentUserIsInRoleAsync(RoleType role);

        bool UserIsPacijent();

        RoleType? TypeOfCurrentUser();

        Task<KorisnickiNalog> LoggedInUser();

        Task<Pacijent> GetCurrentLoggedInPacijent();

        Task<Doktor> GetCurrentLoggedInDoktor();
    }
}