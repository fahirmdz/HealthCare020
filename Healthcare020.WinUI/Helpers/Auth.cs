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
            return (Properties.Settings.Default.ApiUrl + relativePath).WithHeader("Authorization", "Bearer " + AccessToken);
        }

        public static string GetAccessToken() => AccessToken;

        public static bool AuthenticateWithPassword(string username, string password)
        {
            try
            {
                var client = new OAuth2Client(new Uri(Properties.Settings.Default.IdpTokenEndpoint), Properties.Settings.Default.IdpClientId,
                    Properties.Settings.Default.IdpClientSecret);
                var tokens = client.RequestAccessTokenUserName(username, password, string.Empty);
                AccessToken = tokens.AccessToken;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}