using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using ElectronicInvoice.Produce.Base;

namespace ElectronicInvoice.Produce.Helper
{
    public class DesCrypHelper
    {
        private Encoding encoding = Encoding.UTF8;
        private DESCryptoServiceProvider des = new DESCryptoServiceProvider();

        public DesCrypHelper(IKeyProvider provider)
        {
            des.Key = encoding.GetBytes(provider.Key);
            des.IV = encoding.GetBytes(provider.IV);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encryptBytes"></param>
        /// <returns></returns>
        public byte[] DecryptData(byte[] encryptBytes)
        {
            byte[] outputBytes = null;
            using (MemoryStream memoryStream = new MemoryStream(encryptBytes))
            {
                using (CryptoStream decryptStream = new CryptoStream(memoryStream, des.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    MemoryStream outputStream = new MemoryStream();
                    decryptStream.CopyTo(outputStream);
                    outputBytes = outputStream.ToArray();
                }
            }
            return outputBytes;
        }

        public string DecryptData(string encryptData)
        {
            byte[] originalBuffer = Convert.FromBase64String(encryptData);
            byte[] decryptBuffer = DecryptData(originalBuffer);
            return encoding.GetString(decryptBuffer);
        }

        public string EncryptData(string encryptData)
        {
            byte[] originalBuffer = encoding.GetBytes(encryptData);
            byte[] decryptBuffer = EncryptData(originalBuffer);
            return Convert.ToBase64String(decryptBuffer);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] EncryptData(byte[] data)
        {
            byte[] outputBytes = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream encryptStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    MemoryStream inputStream = new MemoryStream(data);
                    inputStream.CopyTo(encryptStream);
                    encryptStream.FlushFinalBlock();
                    outputBytes = memoryStream.ToArray();
                }
            }

            return outputBytes;
        }
    }
}