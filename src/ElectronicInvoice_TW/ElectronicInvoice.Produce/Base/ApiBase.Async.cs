using ElectronicInvoice.Produce.Facade;
using ElectronicInvoice.Produce.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Produce.Base
{
    public abstract partial class ApiBase<TModel> :  IApiRunner<TModel>
        where TModel : class, new()
    {
        public virtual async Task<string> ExecuteApiAsync(TModel model)
        {
            string postData = GetInvoiceParameter(SetParameter(model));

            var result = await HttpTool.HttpPostAsync(GetApiURL(), postData);
            Logger.WriteLog($"Recive Api Result：{result}");
            return result;
        }

        public virtual async Task<TRtn> ExecuteApiAsync<TRtn>(TModel model)
        {
            var result = await this.ExecuteApiAsync(model);
            return JsonConvertFacde.DeserializeObject<TRtn>(result);
        }
    }
}
