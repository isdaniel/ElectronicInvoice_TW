using ElectronicInvoice.Produce.Infrastructure.Helper;
using ElectronicInvoice.Produce.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Base;

namespace ElectronicInvoice.Produce
{
    public class CarrierDetailApi : ApiBase<CarrierDetailModel>
    {

        protected override string SetParamter(CarrierDetailModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();

            paramter["version"] = "0.3";
            paramter["action"] = "carrierInvDetail";
            paramter["cardType"] = "3J0002";
            paramter["cardNo"] = model.cardNo;
            paramter["expTimeStamp"] = model.TimeStampMAX;
            paramter["timeStamp"] = model.TimeStamp;
            paramter["invNum"] = model.invNum;
            paramter["invDate"] = model.invDate;
            paramter["uuid"] = model.UUID;
            paramter["cardEncrypt"] = model.cardEncrypt;
            paramter["appID"] = _config.GovAppId;

            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}