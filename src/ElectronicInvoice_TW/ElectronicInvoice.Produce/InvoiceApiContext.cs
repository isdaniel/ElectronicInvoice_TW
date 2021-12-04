using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Extension;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce
{
    public class InvoiceApiContext
    {
        private Dictionary<Type, object> _apiMapperCache;
        public InvoiceApiContext(IConfig config) : this(config,new ConsoleLog())
        {
           
        }

        public InvoiceApiContext(IConfig config,ISysLog log)
        {
            object[] args = { config,log};
            _apiMapperCache = ApiTypeProvider.Instance
                .GetTypeFromAssembly<ApiTypeAttribute>()
                .ToDictionary(x => x,
                    x => x.GetAttributeValue((ApiTypeAttribute y) => 
                        Activator.CreateInstance(y.ApiType,args)));
        }

        public InvoiceApiContext():this(new AppsettingConfig())
        {
        }

        public string ExecuteApi<TModel>(TModel model) 
            where TModel : class, new()
        {
            return ExecuteApiProcess<TModel, string>(x => x.ExecuteApi(model));
        }

        public TRtn ExecuteApi<TModel,TRtn>(TModel model) 
            where TModel : class, new()
        {
            return ExecuteApiProcess<TModel, TRtn>(x=>x.ExecuteApi<TRtn>(model));
        }

        public Task<TRtn> ExecuteApiAsync<TModel, TRtn>(TModel model)
            where TModel : class, new()
        {
            return ExecuteApiProcess<TModel, Task<TRtn>>(x => x.ExecuteApiAsync<TRtn>(model));
        }

        public Task<string> ExecuteApiAsync<TModel>(TModel model)
            where TModel : class, new()
        {
            return ExecuteApiProcess<TModel, Task<string>>(x => x.ExecuteApiAsync(model));
        }

        private TRtn ExecuteApiProcess<TModel,TRtn>(Func<ApiBase<TModel>, TRtn> fun1)
            where TModel : class, new()
        {
            object apiObject;

            if (_apiMapperCache.TryGetValue(typeof(TModel), out apiObject) &&
                apiObject is ApiBase<TModel>)
            {
                var apiInstance = (ApiBase<TModel>)apiObject;
                return fun1(apiInstance.GetProxyApi());
            }

            throw new NotSupportedException("Can't Get Type from ApiMapperTable.");
        }
    }
}
