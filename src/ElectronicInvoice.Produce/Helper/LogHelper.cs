using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ElectronicInvoice.Produce.Infrastructure.Helper
{
    public class LogHelper
    {
        /// <summary>
        /// 撰寫Log
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        /// <param name="type"></param>
        internal void WriteLog(string fileName, string content, string type)
        {
            fileName = $"{fileName}_{DateTime.Now:yyyyMMdd}_{type}.log";
            string filePath = GetFilePath(fileName);
            File.AppendAllText(filePath, GetLogContent(content));
        }

        private string GetFilePath(string fileName)
        {
            string filePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\log\\";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            return filePath + fileName;
        }

        private string GetLogContent(string content)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"接收時間:{DateTime.Now.ToLongDateString()}");
            sb.AppendLine($"資料:{content}");
            return sb.ToString();
        }
    }
}