using System;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Extension;
using ElectronicInvoice.Produce.Infrastructure.Helper;

namespace ElectronicInvoice.Produce.Factory
{
    public class InvoiceApiFactory
    {
        private IConfig _config;

        public InvoiceApiFactory(IConfig config)
        {
            _config = config;
        }

        public InvoiceApiFactory() : this(new AppsettingConfig())
        {
        }

        /// <summary>
        /// 取得InvocieApi代理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">Model參數</param>
        /// <returns></returns>
        public ApiBase<T> GetProxyInstace<T>(T model, object[] args = null)
            where T : class, new()
        {
            ApiBase<T> realSubject = Activator.CreateInstance(GetApiType(model), args) as ApiBase<T>;

            return realSubject.GetProxyApi(_config);
        }

        /// <summary>
        /// 反射取得綁定Model上綁定的API型別
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        internal Type GetApiType<T>(T model)
            where T : class, new()
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
            return _config.IsMockAPI == "1" ? attr.MockApiType : attr.ApiType;
        }
    }
}