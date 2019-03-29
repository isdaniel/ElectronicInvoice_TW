using System;
using System.Security.Cryptography;
using System.Text;

namespace ElectronicInvoice.Produce.Helper
{
    internal class CiphertextHelper
    {
        /// <summary>
        /// HMACSHA並轉換Base64String
        /// </summary>
        /// <param name="APIKey"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static string EncryptionHMACSHA1Base64(string APIKey, string data)
        {
            byte[] key = Encoding.UTF8.GetBytes(APIKey);
            HMACSHA1 sha1 = new HMACSHA1(key);
            byte[] source = Encoding.UTF8.GetBytes(data);
            byte[] crypto = sha1.ComputeHash(source);
            return Convert.ToBase64String(crypto);
        }
    }
}
