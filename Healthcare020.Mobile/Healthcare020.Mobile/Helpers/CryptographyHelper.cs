using System;
using System.Security.Cryptography;
using System.Text;

namespace Healthcare020.Mobile.Helpers
{
    public static class CryptographyHelper
    {
       private static readonly bool _optimalAsymmetricEncryptionPadding = false;

        public static string Encrypt(this string plainText, string publicKeyXml, int keySize = 4096)
        {
            var encrypted = Encrypt(Encoding.UTF8.GetBytes(plainText), publicKeyXml, keySize);

            return Convert.ToBase64String(encrypted);
        }
        public static string Decrypt(this string encryptedText, string privateKeyXml, int keySize = 4096)
        {
            var decrypted = Decrypt(Convert.FromBase64String(encryptedText), keySize, privateKeyXml);

            return Encoding.UTF8.GetString(decrypted);
        }

        //==========Helpers methods==============
        private static byte[] Encrypt(byte[] data, string publicKeyXml, int keySize = 4096)
        {
            if (data == null || data.Length == 0 || string.IsNullOrEmpty(publicKeyXml) || !IsKeySizeValid(keySize))
                return data;

            int maxLength = GetMaxDataLength(keySize);
            if (data.Length > maxLength)
                return data;

            using var provider = new RSACryptoServiceProvider(keySize);
            provider.FromXmlString(publicKeyXml);

            return provider.Encrypt(data, _optimalAsymmetricEncryptionPadding);
        }


        private static byte[] Decrypt(byte[] data, int keySize, string publicAndPrivateKeyXml)
        {
            if (data == null || data.Length == 0 || !IsKeySizeValid(keySize) || string.IsNullOrEmpty(publicAndPrivateKeyXml))
                return data;

            using var provider = new RSACryptoServiceProvider(keySize);

            provider.FromXmlString(publicAndPrivateKeyXml);
            return provider.Decrypt(data, _optimalAsymmetricEncryptionPadding);
        }

        private static int GetMaxDataLength(int keySize)
        {
            if (_optimalAsymmetricEncryptionPadding)
            {
                return ((keySize - 384) / 8) + 7;
            }
            return ((keySize - 384) / 8) + 37;
        }

        private static bool IsKeySizeValid(int keySize)
        {
            return keySize >= 384 && keySize <= 16384 && keySize % 8 == 0;
        }
    }
}