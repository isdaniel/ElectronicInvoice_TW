using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AOPLib.Core
{
    /// <summary>
    /// 執行前上下文
    /// </summary>
    public class ExcuteingContext
    {
        public ExcuteingContext(IMethodCallMessage callMessage)
        {
            InArgs = callMessage.Args;
            MethodName = callMessage.MethodName;
        }

        public object[] InArgs { get; set; }
        public string MethodName { get; set; }

        public string ClassName { get; internal set; }
    }

    /// <summary>
    /// 執行後上下文
    /// </summary>
    public class ExcutedContext
    {
        public ExcutedContext(IMethodCallMessage callMessage,
            IMethodReturnMessage returnMethod)
        {
            Args = callMessage.Args;
            MethodName = callMessage.MethodName;
            Result = returnMethod;
        }

        public object[] Args { get; set; }
        public string MethodName { get; private set; }

        public IMethodReturnMessage Result { get; private set; }

        public string ClassName { get; internal set; }
    }
}