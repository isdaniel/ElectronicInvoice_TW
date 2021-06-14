using System;
using System.IO;
using System.Text;

namespace ElectronicInvoice.Produce.Infrastructure
{
    public interface ISysLog
    {
        void WriteLog(string content);
    }

    public class ConsoleLog :　ISysLog
    {
        public void WriteLog(string content)
        {
            Console.WriteLine(GetLogContent(content));
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