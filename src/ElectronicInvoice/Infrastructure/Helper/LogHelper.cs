using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ElectronicInvoice.Infrastructure.Helper
{
    public class LogHelper
    {
        internal void WriteLog(string fileName, string content, string type)
        {
            fileName = $"{fileName}_{DateTime.Now.ToString("yyyyMMdd")}_{type}.log";
            string filePath = GetFilePath(fileName);
            File.AppendAllText(filePath, GetLogContent(content));
        }

        private string GetFilePath(string fileName)
        {
            string filePath = string.Empty;
            if (HttpContext.Current != null)
            {
                filePath = HttpContext.Current.Server.MapPath("~/App_Data/");
            }
            else
            {
                filePath = Environment.CurrentDirectory + "/";
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