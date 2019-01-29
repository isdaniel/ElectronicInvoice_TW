using System;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Extention;
using ElectronicInvoice.Produce.Base;
using AwesomeProxy;
using ElectronicInvoice.Produce.Infrastructure.Helper;

namespace ElectronicInvoice.Produce.Factroy
{
    public class InvoiceApiFactroy
    {
        private IConfig _config;

        public InvoiceApiFactroy(IConfig config)
        {
            _config = config;
        }

        public InvoiceApiFactroy():this(new AppsettingConfig())
        {
        }

        /// <summary>
        /// 取得InvocieApi代理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">Model參數</param>
        /// <returns></returns>
        public ApiBase<T> GetProxyInstace<T>(T model,object[] args = null) 
            where T : class, new()
        {
            ApiBase<T> realSubject = Activator.CreateInstance(GetApiType(model), args) as ApiBase<T>;
            realSubject.ConfigSetting = _config;
            return ProxyFactory.GetProxyInstance(realSubject);
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

        //後面改用代理物件
        //public IApiRunner<T> GetInstace<T>(T model, object[] args = null)
        //     where T : class, new()
        //{
        //    if (model == null) throw new ArgumentNullException("傳入Model不能為NULL");

        //    return Activator.CreateInstance
        //        (GetInstanceType(model), args) as IApiRunner<T>;
        //}
    }
}