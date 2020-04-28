using HealthCare020.Core.Models;
using HealthCare020.Services.Interfaces;
using IdentityModel;
using IdentityServer4.Events;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

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

            if (user != null)
            {
                await BuildSuccessResultAsync(user, context);
            }
        }

        private async Task BuildSuccessResultAsync(KorisnickiNalogDtoLL user, ResourceOwnerPasswordValidationContext context, bool sendRememberToken = false)
        {
            await _events.RaiseAsync(new UserLoginSuccessEvent(user.Username, user.Id.ToString(), user.Username, false));

            var claims = new List<Claim>();
            claims.Add(new Claim(JwtClaimTypes.Id, user.Id.ToString()));

            context.Result = new GrantValidationResult(user.Id.ToString(), "Application",
                identityProvider: "Healthcare020_OAuth",
                claims: claims);
        }
    }
}