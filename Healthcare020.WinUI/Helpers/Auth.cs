using Flurl.Http;
using System;
using System.Net;
using System.Security;
using Healthcare020.WinUI.Exceptions;
using Thinktecture.IdentityModel.Clients;

namespace Healthcare020.WinUI.Helpers
{
    public class Auth
    {
        public static SecureString AccessToken { get; private set; }

        public static IFlurlRequest GetAuthorizedApiRequest(string relativePath="")
        {
            if (!IsAuthenticated())
            {
                throw new UnauthorizedException("Niste prijavljeni na sistem!");
            }
            return (Properties.Settings.Default.ApiUrl + relativePath).WithHeader("Authorization", $"Bearer {new NetworkCredential(string.Empty, AccessToken).Password}");
        }

        public static bool AuthenticateWithPassword(string username, string password)
        {
            try
            {
                var client = new OAuth2Client(new Uri(Properties.Settings.Default.IdpTokenEndpoint), Properties.Settings.Default.IdpClientId,
                    Properties.Settings.Default.IdpClientSecret);
                var tokens = client.RequestAccessTokenUserName(username, password, string.Empty);
                AccessToken = new NetworkCredential(string.Empty, tokens.AccessToken).SecurePassword;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void Logout()
        {
            AccessToken = null;
            MainForm.Instance.SetLoginAsChildForm();
        }

        public static bool IsAuthenticated() => AccessToken!=null;
    }
}