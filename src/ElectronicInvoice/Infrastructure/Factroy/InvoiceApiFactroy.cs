using ElectronicInvoice.Service;
using System;
using System.Configuration;
using System.Reflection;
using System.Linq;
using ElectronicInvoice.Infrastructure.Common;
using ElectronicInvoice.Infrastructure.AOP;

namespace ElectronicInvoice.Infrastructure.Factroy
{
    public class MoblieInvoiceApiFactroy
    {
        /// <summary>
        /// InvoiceApiAssemebly名稱
        /// </summary>
        public static string AssemblyName
        {
            get
            {
                string _assemblyname = ConfigurationManager.AppSettings["InvoiceApiAssemebly"];

                if (string.IsNullOrEmpty(_assemblyname))
                {
                    _assemblyname = "ElectronicInvoice.Service";
                }

                return _assemblyname;
            }
        }

        /// <summary>
        /// 提供api的工廠
        /// Model和Api命名要相關
        /// 例如:testModel 對 testApi
        /// </summary>
        /// <param name="model">Model參數</param>
        /// <returns></returns>
        public static IApiRunner GetInstace(object model)
        {
            if (model == null) throw new ArgumentNullException("不能傳空的參數");

            string modelName = model.GetType().Name;
            return (IApiRunner)Activator.CreateInstance
                (GetInstanceType(model), null);
        }

        /// <summary>
        /// 取得InvocieApi代理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ApiBase<T> GetProxyInstace<T>(T model,
            IInterception interception = null) where T : class, new()
        {
            IApiRunner realSubject = GetInstace(model);
            return ProxyFactory.CreateProxyInstance<ApiBase<T>>(realSubject, interception);
        }

        /// <summary>
        /// 反射取得綁定Model上綁定的API型別
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Type GetInstanceType(object model)
        {
            var modelType = model.GetType();
            var attr = modelType.GetCustomAttribute(typeof(ApiTypeAttribute)) as ApiTypeAttribute;
            if (attr != null)
            {
                return GetApiType(attr);
            }
            throw new Exception("Model尚未賦予ApiTypeAttribute");
        }

        private static Type GetApiType(ApiTypeAttribute attr)
        {
            string IsMockAPI = ConfigurationManager.AppSettings["IsMockAPI"] ?? "0";
            if (IsMockAPI == "1")
            {
                return attr.MockApiType;
            }
            return attr.ApiType;
        }
    }
}