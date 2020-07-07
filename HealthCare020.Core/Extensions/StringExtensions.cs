using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;

namespace HealthCare020.Core.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveWhitespaces(this string input)
        {
            return new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }

        public static SecureString ConvertToSecureString(this string str)
        {
            var secureStr = new SecureString();
            if (str.Length > 0)
            {
                foreach (var c in str.ToCharArray()) secureStr.AppendChar(c);
            }
            return secureStr;
        }

        public static string ConvertToString(this SecureString secstrPassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secstrPassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}