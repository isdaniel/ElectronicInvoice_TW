using AOPLib.FilterAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AOPLib.Core;
using Newtonsoft.Json;
using ElectronicInvoice.Infrastructure.Helper;

namespace ElectronicInvoice.Infrastructure.Attributes
{
    public class LogAttribute : AopBaseAttribute
    {
        private LogHelper log = new LogHelper();

        public override void MethodExcuted(ExcutedContext result)
        {
            var resultJson = JsonConvert.SerializeObject(result);
            log.WriteLog("ExcuteAfter", resultJson, result.MethodName);
        }

        public override void MethodExcuting(ExcuteingContext args)
        {
            var resultJson = JsonConvert.SerializeObject(args.InArgs);
            log.WriteLog("ExcuteBefore", resultJson, args.MethodName);
        }
    }
}