using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ElectronicInvoice.Infrastructure.Helper
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