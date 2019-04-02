using System;
using System.Collections.Generic;
using System.Linq;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Extension;
using ElectronicInvoice.Produce.Helper;

namespace ElectronicInvoice.Produce
{
    public class InvoiceApiContext
    {
        private static Dictionary<Type, object> _apiMapperCache;
        private readonly IConfig _config;
        public InvoiceApiContext(IConfig config)
        {
            _apiMapperCache = ApiTypeProvider.Instance
                         .GetTypeFromAssembly<ApiTypeAttribute>()
                         .ToDictionary(x => x,
                              x => x.GetAttributeValue((ApiTypeAttribute y) => 
                                 Activator.CreateInstance(y.ApiType)));
            _config = config ;
        }

        public InvoiceApiContext():this(new AppsettingConfig())
        {
        }

        public string ExecuteApi<TModel>(TModel model) 
            where TModel : class, new()
        {
            return ExecuteApiProcess(model, x => x.ExecuteApi(model));
        }

        public TRtn ExecuteApi<TModel,TRtn>(TModel model) 
            where TModel : class, new()
        {
            return ExecuteApiProcess(model, x=>x.ExecuteApi<TRtn>(model));
        }

        private TRtn ExecuteApiProcess<TModel,TRtn>(TModel model,Func<ApiBase<TModel>, TRtn> fun1)
            where TModel : class, new()
        {
            object apiObject;

            if (_apiMapperCache.TryGetValue(typeof(TModel), out apiObject) &&
                apiObject is ApiBase<TModel>)
            {
                var apiInstance = (ApiBase<TModel>)apiObject;
                return fun1(apiInstance.GetProxyApi(_config));
            }

            throw new Exception("Can't Get Type from ApiMapperTable.");
        }
    }
}
