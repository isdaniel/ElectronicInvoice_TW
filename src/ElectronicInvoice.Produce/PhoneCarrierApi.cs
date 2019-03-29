using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce
{
    internal sealed class QryCarrierAggApi : ApiBase<qryCarrierAggModel>
    {
        protected override string SetParameter(qryCarrierAggModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();

            paramter["version"] = "1.0";
            paramter["serial"] = DateTime.Now.ToString("MMddssmmss");
            paramter["action"] = ActionParameter.QryCarrierAggApi;
            paramter["cardType"] = "3J0002";
            paramter["cardNo"] = model.cardNo;
            paramter["cardEncrypt"] = model.cardEncrypt;
            paramter["timeStamp"] = model.TimeStamp;
            paramter["uuid"] = model.UUID; ;
            paramter["appID"] = ConfigSetting.GovAppId;

            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}
