using System;
using ElectronicInvoice.Service.Base;
using AOPLib.Core;
using ElectronicInvoice.Produce.Infrastructure.Helper;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Extention;

namespace ElectronicInvoice.Produce.Factroy
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
        public IApiRunner<T> GetInstace<T>(T model)
        {
            if (model == null) throw new ArgumentNullException("不能傳空的參數");

            return Activator.CreateInstance
                (GetInstanceType(model), null) as IApiRunner<T>;
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
        private Type GetInstanceType(object model)
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
            string IsMockAPI = "0";//new ConfigHelper().IsMockAPI ?? "0";
            if (IsMockAPI == "1")
            {
                return attr.MockApiType;
            }
            return attr.ApiType;
        }
    }
}