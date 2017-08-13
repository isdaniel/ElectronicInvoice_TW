using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicInvoice.Infrastructure.AOP
{
    /// <summary>
    /// 動態代理工廠
    /// </summary>
    public class ProxyFactory
    {
        /// <summary>
        /// 取得動態產生的代理物件
        /// </summary>
        /// <typeparam name="T">被代理物件型別</typeparam>
        /// <param name="realSubject">被代理物件</param>
        /// <param name="interception">使用攔截器</param>
        /// <returns></returns>
        public static T CreateProxyInstance<T>(object realSubject, IInterception interception = null)
        {
            CheckType(realSubject);

            var aopRealProxy = new AOPRealProxy(realSubject);
            if (interception != null)
            {
                aopRealProxy.InterceptionDI(interception);
            }
            return (T)aopRealProxy.GetTransparentProxy();
        }
        /// <summary>
        /// 被代理物件需繼承MarshalByRefObject
        /// </summary>
        /// <param name="realSubject"></param>

        private static void CheckType(object realSubject)
        {
            var obj = realSubject as MarshalByRefObject;
            if (obj == null)
            {
                throw new ArgumentException("被代理對象需繼承於MarshalByRefObject");
            }
        }
    }
}