using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Infrastructure.Helper;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce
{
    public class DonateQueryApi : ApiBase<DonateQueryModel>
    {
        protected override string SetParamter(DonateQueryModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();
            paramter["version"] = "0.2";
            paramter["qKey"] = model.qKey;
            paramter["action"] = "qryLoveCode";
            paramter["uuid"] = model.UUID;
            paramter["appID"] = _config.GovAppId;
            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}
