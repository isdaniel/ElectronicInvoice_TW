﻿using System;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Extension;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Factory
{
    public class InvoiceApiFactory
    {
        private IConfig _config;
        private ISysLog _log;

        public InvoiceApiFactory(IConfig config) : this(config,new ConsoleLog())
        {
          
        }

        public InvoiceApiFactory(IConfig config,ISysLog log)
        {
            _config = config;
            _log = log;
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
        public ApiBase<T> GetProxyInstace<T>(T model)
            where T : class, new()
        {
            object[] args = { _config,_log};
            ApiBase<T> realSubject = Activator.CreateInstance(GetApiType(model), args) as ApiBase<T>;

            return realSubject.GetProxyApi();
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
                    return attr.ApiType;
                }
                throw new Exception("Model尚未賦予ApiTypeAttribute");
            });
        }
    }
}