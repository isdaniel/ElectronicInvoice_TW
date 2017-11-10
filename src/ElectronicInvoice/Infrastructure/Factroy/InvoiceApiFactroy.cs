using ElectronicInvoice.Service;
using System;
using System.Configuration;
using System.Reflection;
using System.Linq;
using ElectronicInvoice.Infrastructure.Common;
using AOPLib.Core;
using ElectronicInvoice.Infrastructure.Extention;
using ElectronicInvoice.Infrastructure.Helper;

namespace ElectronicInvoice.Infrastructure.Factroy
{
    public class MoblieInvoiceApiFactroy
    {
        /// <summary>
        /// InvoiceApiAssemebly名稱
        /// </summary>
        public string AssemblyName
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
        public IApiRunner GetInstace(object model)
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
        public ApiBase<T> GetProxyInstace<T>(T model) where T : class, new()
        {
            IApiRunner realSubject = GetInstace(model);
            return ProxyFactory.GetProxyInstance<ApiBase<T>>();
        }

        /// <summary>
        /// 反射取得綁定Model上綁定的API型別
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Type GetInstanceType(object model)
        {
            var modelType = model.GetType();
            return modelType.GetAttributeValue((ApiTypeAttribute attr) =>
            {
                if (attr != null)
                {
                    return GetApiType(attr);
                }
                throw new Exception("Model尚未賦予ApiTypeAttribute");
            });
        }

        private static Type GetApiType(ApiTypeAttribute attr)
        {
            string IsMockAPI = new ConfigHelper().IsMockAPI ?? "0";
            if (IsMockAPI == "1")
            {
                return attr.MockApiType;
            }
            return attr.ApiType;
        }
    }
}