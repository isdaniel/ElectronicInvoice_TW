using Newtonsoft.Json;
using AwesomeProxy.FilterAttribute;
using AwesomeProxy;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Attributes
{
    /// <summary>
    /// 使用Awesome.AOP 函式庫
    /// </summary>
    public class LogAttribute : AopBaseAttribute
    {
        private ISysLog _log;
        public LogAttribute()
        {
            _log = InvoiceContainer.Instance.GetObject<ISysLog>();
        }

        public override void OnExcuted(ExcutedContext context)
        {
            
            var resultJson = JsonConvert.SerializeObject(context.Result);
            _log.WriteLog($"ExecuteAfter: {resultJson}");
        }

        public override void OnExcuting(ExcuteingContext context)
        {
            var resultJson = JsonConvert.SerializeObject(context.Args);
            _log.WriteLog($"ExecuteAfter: {resultJson}");
        }

        public override void OnException(ExceptionContext context)
        {
            _log.WriteLog($"Error: {context.Exception.ToString()}");
            context.Result = GetSysErrorMsg();
        }

        //提供預設錯誤資料
        private string GetSysErrorMsg()
        {
            var result = new
            {
                v = "1.0",
                code = "9999",
                msg = "執行過程中發生錯誤，請提Issues至GitHub! https://github.com/isdaniel/ElectronicInvoice_TW/issues"
            };

            return Facade.JsonConvertFacde.SerializeObject(result);
        }
    }
}