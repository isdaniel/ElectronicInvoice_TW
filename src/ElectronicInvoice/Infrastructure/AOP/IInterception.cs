using ElectronicInvoice.Infrastructure.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Infrastructure.AOP
{
    /// <summary>
    /// 攔截器介面
    /// </summary>
    public interface IInterception
    {
        /// <summary>
        /// 執行方法前
        /// </summary>
        void PreInvoke(IMethodCallMessage methodCall);

        /// <summary>
        /// 執行方法後
        /// </summary>
        void PostInvoke(IMethodReturnMessage methodReturn);

        /// <summary>
        /// 調用時出錯
        /// </summary>
        void ExceptionHandle(IMethodReturnMessage methodReturn);
    }

    internal interface IProxyDI
    {
        void InterceptionDI(IInterception interception);
    }

    /// <summary>
    /// Log攔截器
    /// </summary>
    public class LogInterception : IInterception
    {
        public void PreInvoke(IMethodCallMessage methodCall)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var arg in methodCall.Args)
            {
                sb.AppendLine(JsonConvert.SerializeObject(arg));
            }
            WriteLog(sb.ToString(), "Before");
        }

        public void PostInvoke(IMethodReturnMessage methodReturn)
        {
            WriteLog(JsonConvert.SerializeObject(methodReturn.ReturnValue), "After");
        }

        public void ExceptionHandle(IMethodReturnMessage methodReturn)
        {
        }

        /// <summary>
        /// 紀錄Log
        /// </summary>
        /// <param name="content">內容</param>
        /// <param name="type">寄送或是接收</param>
        private void WriteLog(string content, string type)
        {
            LogHelper log = new LogHelper();
            string apiname = this.GetType().Name;
            string fileName = string.Format("{0}CellphonCarrier", apiname);

            log.WriteLog(fileName, content, type);
        }
    }
}