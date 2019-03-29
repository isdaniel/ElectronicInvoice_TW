using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce
{
    internal sealed class DonateQueryApi : ApiBase<DonateQueryModel>
    {
        protected override string SetParameter(DonateQueryModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();
            paramter["version"] = "0.2";
            paramter["qKey"] = model.qKey;
            paramter["action"] = ActionParameter.DonateQueryApi;
            paramter["uuid"] = model.UUID;
            paramter["appID"] = ConfigSetting.GovAppId;
            return ParameterHelper.DictionaryToParameter(paramter);
        }
    }
}
