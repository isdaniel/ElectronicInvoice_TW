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
    }
}