using Flurl.Http;
using System;
using Thinktecture.IdentityModel.Clients;

namespace Healthcare020.WinUI.Helpers
{
    public class Auth
    {
        private static string AccessToken { get; set; } = string.Empty;

        public static IFlurlRequest GetAuthorizedApiRequest(string relativePath)
        {
            return ("https://localhost:5001/api/" + relativePath).WithHeader("Authorization", "Bearer " + AccessToken);
        }

        public static string GetAccessToken() => AccessToken;

        public static void AuthenticateWithPassword(string username, string password)
        {
            try
            {
                var client = new OAuth2Client(new Uri("https://localhost:5005/connect/token"), "Healthcare020_WebAPI",
                    "devsecret");
                var tokens = client.RequestAccessTokenUserName(username, password, string.Empty);
                AccessToken = tokens.AccessToken;
            }
            catch (Exception ex)
            {
                // ignored
            }
        }
    }
}