using System;
using ElectronicInvoice.Core.Infrastructure.Attributes;
using ElectronicInvoice.Core.Infrastructure.Extention;
using ElectronicInvoice.Core.Infrastructure.Helper;
using ElectronicInvoice.Service.Base;
using AOPLib.Core;

namespace ElectronicInvoice.Core.Infrastructure.Factroy
{
    public class MoblieInvoiceApiFactroy
    {
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

            return (IApiRunner)Activator.CreateInstance
                (GetInstanceType(model), null);
        }

        /// <summary>
        /// 取得InvocieApi代理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">Model參數</param>
        /// <returns></returns>
        public ApiBase<T> GetProxyInstace<T>(T model) where T : class, new()
        {
            ApiBase<T> realSubject = GetInstace(model) as ApiBase<T>;
            return ProxyFactory.GetProxyInstance(realSubject);
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