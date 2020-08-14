using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace HealthCare020.Services.Helpers
{
    public static class AuthExtensions
    {
        public static int? GetUserIdFromIdentityClaim(this HttpContext context)
        {
            var claimsdentity = context.User.Identity as ClaimsIdentity;
            var claim = claimsdentity?.Claims.FirstOrDefault(x => x.Type == "sub");

            int.TryParse(claim?.Value, out int parsedId);

            return parsedId;
        }
    }
}