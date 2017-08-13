using ElectronicInvoice.Infrastructure.AOP;
using ElectronicInvoice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicInvoice.Infrastructure.Factroy
{
    /// <summary>
    /// 動態代理工廠
    /// </summary>
    public class ProxyFactory
    {
        public static T CreateProxyInstance<T>(object realSubject)
        {
            var aopRealProxy = new AOPRealProxy(realSubject);
            return (T)aopRealProxy.GetTransparentProxy();
        }

        public static ApiBase<T> GetApiProxy<T>(T realSubject) where T : class
        {
            return CreateProxyInstance<ApiBase<T>>(realSubject);
        }
    }
}