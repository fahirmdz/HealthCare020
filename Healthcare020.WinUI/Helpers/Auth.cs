using Flurl.Http;
using Healthcare020.WinUI.Exceptions;
using Healthcare020.WinUI.Forms;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using System;
using System.Linq;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using HealthCare020.Core.Enums;
using Thinktecture.IdentityModel.Clients;

namespace Healthcare020.WinUI.Helpers
{
    public class Auth
    {
        public static SecureString AccessToken { get; private set; }

        /// <summary>
        /// Current logged in user
        /// </summary>
        public static KorisnickiNalogDtoLL KorisnickiNalog { get; private set; }

        /// <summary>
        /// Role of current logged in user
        /// </summary>
        public static RoleType Role { get; private set; }


        public static IFlurlRequest GetAuthorizedApiRequest(string relativePath = "")
        {
            if (!IsAuthenticated())
            {
                throw new UnauthorizedException("Niste prijavljeni na sistem!");
            }
            return (Properties.Settings.Default.ApiUrl + relativePath).WithHeader("Authorization", $"Bearer {new NetworkCredential(string.Empty, AccessToken).Password}");
        }

        /// <summary>
        /// Authenticate user with username and password and get access token (store it in Auth.AccessToken)
        /// </summary>
        /// <returns>Returns boolean that indicates operation was succeeded or no</returns>
        public static  async Task<bool> AuthenticateWithPassword(string username, string password)
        {
            try
            {
                var client = new OAuth2Client(new Uri(Properties.Settings.Default.IdpTokenEndpoint), Properties.Settings.Default.IdpClientId,
                    Properties.Settings.Default.IdpClientSecret);
                var tokens = client.RequestAccessTokenUserName(username, password, string.Empty);
                AccessToken = new NetworkCredential(string.Empty, tokens.AccessToken).SecurePassword;

                var apiSerivce = new APIService(Routes.KorisniciRoute);

                var result = await apiSerivce.GetById<KorisnickiNalogDtoLL>(0);
                if (!result.Succeeded)
                {
                    AccessToken = null;
                    return false;
                }
                KorisnickiNalog = result.Data;

                var topRole = KorisnickiNalog.Roles.Min(x=>x);
                Role = (RoleType) topRole;

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

        public static bool IsAuthenticated() => AccessToken != null;
    }
}