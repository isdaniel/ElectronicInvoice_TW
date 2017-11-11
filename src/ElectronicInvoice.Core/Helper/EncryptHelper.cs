using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ElectronicInvoice.Core.Infrastructure.Helper
{
    public class DESCrypHelper
    {
        private IConfig config = new ConfigHelper();
        private byte[] key;
        private byte[] iv;
        private DESCryptoServiceProvider des;

        public DESCrypHelper()
        {
            key = Encoding.UTF8.GetBytes(config.Key);
            iv = Encoding.UTF8.GetBytes(config.IV);
            des = new DESCryptoServiceProvider();
            des.Key = key;
            des.IV = iv;
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
            return Encoding.UTF8.GetString(decryptBuffer);
        }

        public string EncryptData(string encryptData)
        {
            byte[] originalBuffer = Convert.FromBase64String(encryptData);
            byte[] decryptBuffer = EncryptData(originalBuffer);
            return Encoding.UTF8.GetString(decryptBuffer);
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