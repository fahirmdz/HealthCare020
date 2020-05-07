using Flurl.Http;
using System;
using Healthcare020.WinUI.Exceptions;
using Thinktecture.IdentityModel.Clients;

namespace Healthcare020.WinUI.Helpers
{
    public class Auth
    {
        public static string AccessToken { get; private set; } = string.Empty;

        public static IFlurlRequest GetAuthorizedApiRequest(string relativePath)
        {
            if (!IsAuthenticated())
            {
                throw new UnauthorizedException("Niste prijavljeni na sistem!");
            }
            return (Properties.Settings.Default.ApiUrl + relativePath).WithHeader("Authorization", $"Bearer {AccessToken}");
        }

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

        public static void Logout()
        {
            AccessToken = string.Empty;
            MainForm.Instance.SetLoginAsChildForm();
        }

        public static bool IsAuthenticated() => !string.IsNullOrWhiteSpace(AccessToken);
    }
}