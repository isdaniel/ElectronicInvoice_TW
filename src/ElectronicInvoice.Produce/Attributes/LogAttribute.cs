using AOPLib.FilterAttribute;
using AOPLib.Core;
using Newtonsoft.Json;
using ElectronicInvoice.Produce.Infrastructure.Helper;

namespace ElectronicInvoice.Produce.Attributes
{
    public class LogAttribute : AopBaseAttribute
    {
        private LogHelper log = new LogHelper();

        public override void MethodExcuted(ExcutedContext result)
        {
            var resultJson = JsonConvert.SerializeObject(result.Result.ReturnValue);
            log.WriteLog("ExcuteAfter", resultJson, result.ClassName);
        }

        public override void MethodExcuting(ExcuteingContext args)
        {
            var resultJson = JsonConvert.SerializeObject(args.InArgs);
            log.WriteLog("ExcuteBefore", resultJson, args.ClassName);
        }
    }
}