using Healthcare020.OAuth.Configuration;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Enums;
using HealthCare020.Services.Interfaces;
using IdentityModel;
using IdentityServer4.Events;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Healthcare020.OAuth.Validators
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IKorisnikService _korisnikService;
        private readonly IEventService _events;

        public ResourceOwnerPasswordValidator(IKorisnikService korisnikService, IEventService events)
        {
            _korisnikService = korisnikService;
            _events = events;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //Only for patients (mobile client)
            if (context.Request.ClientId == OAuthConstants.MobileClientId && context.Request.Scopes.Any(x => x.StartsWith(InMemoryConfig.FaceRecognitionScope)))
            {
                if (FaceIDSecretsManager.IsValidSecret(Guid.Parse(context.Password)))
                {
                    var usernameAndId = context.UserName.Split('*');
                    if (usernameAndId.Length <= 1)
                        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidTarget, "Invalid Face ID");
                    var username = usernameAndId[0];
                    var userId = usernameAndId[1];

                    await BuildSuccessResultAsync(username, userId, context);
                }
                else
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidTarget, "Invalid Face ID");
                }
            }
            else
            {
                var user = await _korisnikService.Authenticate(context.UserName, context.Password);

                if (user == null)
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidTarget, "Invalid credentials");
                    return;
                }

                if (string.IsNullOrWhiteSpace(context.UserName) || string.IsNullOrWhiteSpace(context.Password))
                    return;


                if (!user.Roles.Any())
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidTarget, "Invalid credentials");
                    return;
                }

                //E.g. role with Id = 1 is Administrator, Id = 2 is Doktor, etc.. Here is role with the lowest value of ID (highest permissions)
                var leadRole = user.Roles.Min();

                //1. condition -> If mobile client request access token and user doesn't have Pacijent role
                //2. condition -> If desktop client request access token and user doesn't have one of these roles => Administrator, Doktor or RadnikPrijem
                if ((context.Request.ClientId == OAuthConstants.MobileClientId && !RoleType.Pacijent.EqualInt(leadRole))
                    || (context.Request.ClientId == OAuthConstants.DesktopClientId && !RoleType.Administrator.EqualInt(leadRole)
                                                                                   && !RoleType.Doktor.EqualInt(leadRole)
                                                                                   && !RoleType.MedicinskiTehnicar.EqualInt(leadRole)
                                                                                   && !RoleType.RadnikPrijem.EqualInt(leadRole)))
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidTarget, "Invalid credentials");
                    return;
                }

                await BuildSuccessResultAsync(user.Username, user.Id.ToString(), context);
            }
        }

        private async Task BuildSuccessResultAsync(string username, string userId, ResourceOwnerPasswordValidationContext context)
        {
            await _events.RaiseAsync(new UserLoginSuccessEvent(username, userId, username, false));

            var claims = new List<Claim> { new Claim(JwtClaimTypes.Id, userId) };

            context.Result = new GrantValidationResult(userId, "Application",
                identityProvider: "Healthcare020_OAuth",
                claims: claims);
        }
    }
}