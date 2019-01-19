using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Extention;
using ElectronicInvoice.Produce.Factroy;

namespace ElectronicInvoice.Produce
{
    public class InvoiceApiContext
    {
        private static Dictionary<Type, object> _apiMapperCache;

        public InvoiceApiContext()
        {
            var assembly= Assembly.Load("ElectronicInvoice.Produce");
            _apiMapperCache = assembly.ExportedTypes
               .Where(x => x.GetCustomAttribute<ApiTypeAttribute>() != null)
               .ToDictionary(x => x,
                             x => x.GetAttributeValue((ApiTypeAttribute y) => 
                                 Activator.CreateInstance(y.ApiType)));
        }

        public string ExcuteApi<T>(T model)
            where T : class, new()
        {
            object apiObject;

            if (_apiMapperCache.TryGetValue(typeof(T), out apiObject) && 
                apiObject is ApiBase<T>)
            {
                return ((ApiBase<T>)apiObject).ExcuteApi(model);
            }

            throw new Exception("Error");
        }
    }
}
