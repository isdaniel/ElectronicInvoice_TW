using System.Collections.Generic;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce.API.Application
{
    internal sealed class InvoiceTitleApi : ApiBase<InvoiceTitleModel>
    {
        protected override string SetParameter(InvoiceTitleModel model)
        {
            SortedDictionary<string, string> parameter = new SortedDictionary<string, string>
            {
                ["version"] = "0.3",
                ["type"] = model.Type.ToString(),
                ["InvNum"] = model.InvNum,
                ["action"] = GetMapperAction,
                ["generation"] = "V2",
                ["invDate"] = model.InvDate.ToString("yyyy/MM/dd"),
                ["UUID"] = model.UUID,
                ["appID"] = ConfigSetting.GovAppId
            };

            return ParameterHelper.DictionaryToParameter(parameter);
        }
    }
}