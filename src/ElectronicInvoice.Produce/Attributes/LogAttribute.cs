using Newtonsoft.Json;
using ElectronicInvoice.Produce.Infrastructure.Helper;
using AwesomeProxy.FilterAttribute;
using AwesomeProxy;

namespace ElectronicInvoice.Produce.Attributes
{
    /// <summary>
    /// 使用Awesome.AOP 函式庫
    /// </summary>
    public class LogAttribute : AopBaseAttribute
    {
        private LogHelper log = new LogHelper();

        public override void OnExcuted(ExcutedContext context)
        {
            var resultJson = JsonConvert.SerializeObject(context.Result);
            log.WriteLog("ExcuteAfter", resultJson, context.MethodName);
        }

        public override void OnExcuting(ExcuteingContext context)
        {
            var resultJson = JsonConvert.SerializeObject(context.Args);
            log.WriteLog("ExcuteBefore", resultJson, context.MethodName);
        }

        public override void OnException(ExceptionContext context)
        {
            log.WriteLog("ExcuteBefore", 
                context.Exception.ToString(), 
                context.MethodName);
            context.Result = GetSysErrorMsg();
        }

        //提供預設錯誤資料
        private string GetSysErrorMsg()
        {
            var result = new
            {
                v = "1.0",
                code = "999",
                msg = "財政部電子發票資訊中心系統異常，請稍候再試或洽客服人員"
            };
            return Facade.JsonConvertFacde.SerializeObject(result);
        }
    }
}