using System;
using System.Security.Cryptography;
using System.Text;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.Services.Services
{
    public class SecurityService:ISecurityService
    {
        public string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA512");
            if (algorithm != null)
            {
                byte[] inArray = algorithm.ComputeHash(dst);
                return Convert.ToBase64String(inArray);
            }

            return string.Empty;
        }
    }
}