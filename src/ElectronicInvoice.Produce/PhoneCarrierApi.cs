using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Infrastructure.Helper;
using ElectronicInvoice.Produce.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Produce
{
    public class QryCarrierAggApi : ApiBase<qryCarrierAggModel>
    {
        protected override string SetParamter(qryCarrierAggModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();

            paramter["version"] = "1.0";
            paramter["serial"] = DateTime.Now.ToString("MMddssmmss");
            paramter["action"] = "qryCarrierAgg";
            paramter["cardType"] = "3J0002";
            paramter["cardNo"] = model.cardNo;
            paramter["cardEncrypt"] = model.cardEncrypt;
            paramter["timeStamp"] = model.CommonProp.TimeStamp;
            paramter["uuid"] = paramterContext.UUID;
            paramter["appID"] = paramterContext.GovAppId;

            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}
