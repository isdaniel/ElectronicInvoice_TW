using AOPLib.Core;
using AOPLib.FilterAttribute;
using AOPLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace AOPLib
{
    public class DynamicProxy<T> : RealProxy
        where T : MarshalByRefObject
    {
        private T _target;

        public DynamicProxy(T target) : base(typeof(T))
        {
            _target = target;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage callMethod = msg as IMethodCallMessage;
            MethodInfo targetMethod = callMethod.MethodBase as MethodInfo;
            IMethodReturnMessage returnMethod = null;

            var Attrs = new FilterInfo(_target, targetMethod);

            try
            {
                //封裝執行前上下文
                ExcuteingContext excuteContext = new ExcuteingContext(callMethod);
                Excuting(Attrs.ExcuteFilters, excuteContext);
                var result = targetMethod.Invoke(_target, excuteContext.InArgs);
                returnMethod = new ReturnMessage(result,
                                      excuteContext.InArgs,
                                      excuteContext.InArgs.Length,
                                      callMethod.LogicalCallContext,
                                      callMethod);
                //封裝執行後上下文
                ExcutedContext excutingContext = new ExcutedContext(callMethod, returnMethod);
                Excuted(Attrs.ExcuteFilters, excutingContext);
            }
            catch (Exception ex)
            {
                returnMethod = new ReturnMessage(ex, callMethod);
            }
            return returnMethod;
        }

        private void Excuted(IList<IExcuteFilter> filters, ExcutedContext excuteContext)
        {
            foreach (var item in filters)
            {
                item.MethodExcuted(excuteContext);
            }
        }

        private void Excuting(IList<IExcuteFilter> filters, ExcuteingContext excuteContext)
        {
            foreach (var item in filters)
            {
                item.MethodExcuting(excuteContext);
            }
        }
    }
}