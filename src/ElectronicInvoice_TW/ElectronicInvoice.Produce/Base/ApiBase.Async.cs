using ElectronicInvoice.Produce.Facade;
using ElectronicInvoice.Produce.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Produce.Base
{
    public abstract partial class ApiBase<TModel> : MarshalByRefObject, IApiRunner<TModel>
        where TModel : class, new()
    {
        public Task<string> ExecuteApiAsync(TModel model)
        {
            string postData = GetInvoiceParameter(SetParameter(model));

            return HttpTool.HttpPostAsync(GetApiURL(), postData);
        }

        public async Task<TRtn> ExecuteApiAsync<TRtn>(TModel model)
        {
            var result = await ExecuteApiAsync(model);
            return JsonConvertFacde.DeserializeObject<TRtn>(result);
        }
    }
}
