using System;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Extention;
using ElectronicInvoice.Produce.Base;
using AwesomeProxy;

namespace ElectronicInvoice.Produce.Factroy
{
    public class InvoiceApiFactroy
    {
        private IConfig _config;

        public InvoiceApiFactroy(IConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// 取得InvocieApi代理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">Model參數</param>
        /// <returns></returns>
        public ApiBase<T> GetProxyInstace<T>(T model,object[] args = null) where T : class, new()
        {
            ApiBase<T> realSubject = GetInstace(model, args) as ApiBase<T>;
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

        private Type GetApiType(ApiTypeAttribute attr)
        {
            string IsMockAPI = _config.IsMockAPI;
            if (IsMockAPI == "1")
            {
                return attr.MockApiType;
            }
            return attr.ApiType;
        }

        public IApiRunner<T> GetInstace<T>(T model, object[] args = null)
        {
            if (model == null) throw new ArgumentNullException("不能傳空的參數");

            return Activator.CreateInstance
                (GetInstanceType(model), args) as IApiRunner<T>;
        }
    }
}