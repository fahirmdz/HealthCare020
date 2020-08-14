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
        bool UserIsDoktor();

        RoleType? TypeOfCurrentUser();

        Task<KorisnickiNalog> LoggedInUser();

        Task<Pacijent> GetCurrentLoggedInPacijent(bool eagerLoaded=false);


        Task<Doktor> GetCurrentLoggedInDoktor();
    }
}