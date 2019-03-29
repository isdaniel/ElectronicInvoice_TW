using System;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Mapping;
using System.Collections.Generic;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce
{
    internal sealed class InvoiceTitleApi : ApiBase<InvoiceTitleModel>
    {
        protected override string SetParameter(InvoiceTitleModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();
            paramter["version"] = "0.3";
            paramter["type"] = model.Type.ToString();
            paramter["invNum"] = model.InvNum;
            paramter["action"] = ActionParameter.InvoiceTitleApi;
            paramter["generation"] = "V2";
            paramter["invDate"] = model.InvDate.ToString("yyyy/MM/dd");
            paramter["UUID"] = model.UUID;
            paramter["appID"] = ConfigSetting.GovAppId;

            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}