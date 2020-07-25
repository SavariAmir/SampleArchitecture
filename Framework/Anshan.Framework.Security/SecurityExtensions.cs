using System;
using System.Security.Cryptography;
using System.Text;

namespace Anshan.Framework.Security
{
    public static class SecurityExtensions
    {
        public static string ToHash(this string text)
        {
            using (var hashAlgorithm = new SHA256CryptoServiceProvider())
            {
                var byteValue = Encoding.UTF8.GetBytes(text);
                var byteHash = hashAlgorithm.ComputeHash(byteValue);
                return Convert.ToBase64String(byteHash);
            }
        }
    }
}