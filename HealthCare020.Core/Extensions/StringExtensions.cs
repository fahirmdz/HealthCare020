using System;
using System.IO;
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

        public static string ReplaceFirstOccurrence(this string Source, string Find, string Replace)
        {
            if (string.IsNullOrWhiteSpace(Source))
                return string.Empty;

            int Place = Source.IndexOf(Find, StringComparison.Ordinal);
            if (Place == -1)
                return Source;
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }

        public static string ReplaceLastOccurrence(this string Source, string Find, string Replace)
        {
            if (string.IsNullOrWhiteSpace(Source))
                return string.Empty;

            int Place = Source.LastIndexOf(Find, StringComparison.Ordinal);
            if (Place == -1)
                return Source;

            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }

        public static string ToTitleCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;
            return str.Replace(str[0], char.ToUpper(str[0]));
        }

        public static string FirstLetterLower(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;
            return str.Replace(str[0], char.ToLower(str[0]));
        }

        public static string FirstLetterUpper(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            return str.Replace(str[0], char.ToUpper(str[0]));
        }

        public static string CombinePaths(this string rootPath, string relativePath)
        {
            DirectoryInfo dir = new DirectoryInfo(rootPath);
            while (relativePath.StartsWith("..\\"))
            {
                dir = dir.Parent;
                relativePath = relativePath.Substring(3);
            }
            return Path.Combine(dir.FullName, relativePath);
        }
    }
}