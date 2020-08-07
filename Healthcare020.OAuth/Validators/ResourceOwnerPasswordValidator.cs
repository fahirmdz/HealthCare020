using HealthCare020.Core.Models;
using HealthCare020.Services.Interfaces;
using IdentityModel;
using IdentityServer4.Events;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Enums;
using IdentityServer4.Models;

namespace Healthcare020.OAuth.Validators
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IKorisnikService _korisnikService;
        private IEventService _events;

        public ResourceOwnerPasswordValidator(IKorisnikService korisnikService, IEventService events)
        {
            _korisnikService = korisnikService;
            _events = events;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _korisnikService.Authenticate(context.UserName, context.Password);

            if (user == null)
            {
                context.Result=new GrantValidationResult(TokenRequestErrors.InvalidTarget,"Invalid credentials");
                return;
            }

            if (string.IsNullOrWhiteSpace(context.UserName) || string.IsNullOrWhiteSpace(context.Password))
                return;

            var korisnickiNalog = await _korisnikService.Authenticate(context.UserName,context.Password);

            if (korisnickiNalog == null || !korisnickiNalog.Roles.Any())
            {
                context.Result=new GrantValidationResult(TokenRequestErrors.InvalidTarget,"Invalid credentials");
                return;
            }

            //E.g. role with Id = 1 is Administrator, Id = 2 is Doktor, etc.. Here is role with the lowest value of ID (highest permissions)
            var leadRole = korisnickiNalog.Roles.Min();

            //1. condition -> If mobile client request access token and user doesn't have Pacijent role
            //2. condition -> If desktop client request access token and user doesn't have one of these roles => Administrator, Doktor or RadnikPrijem
            if ((context.Request.ClientId == OAuthConstants.MobileClientId && !RoleType.Pacijent.EqualInt(leadRole))
                || (context.Request.ClientId == OAuthConstants.DesktopClientId && !RoleType.Administrator.EqualInt(leadRole)
                                                                               && !RoleType.Doktor.EqualInt(leadRole) && !RoleType.RadnikPrijem.EqualInt(leadRole)))
            {
                context.Result=new GrantValidationResult(TokenRequestErrors.InvalidTarget,"Invalid credentials");
                return;
            }

            await BuildSuccessResultAsync(user, context);
        }

        private async Task BuildSuccessResultAsync(KorisnickiNalogDtoLL user, ResourceOwnerPasswordValidationContext context, bool sendRememberToken = false)
        {
            await _events.RaiseAsync(new UserLoginSuccessEvent(user.Username, user.Id.ToString(), user.Username, false));

            var claims = new List<Claim> {new Claim(JwtClaimTypes.Id, user.Id.ToString())};

            context.Result = new GrantValidationResult(user.Id.ToString(), "Application",
                identityProvider: "Healthcare020_OAuth",
                claims: claims);
        }
    }
}