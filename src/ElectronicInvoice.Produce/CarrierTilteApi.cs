using ElectronicInvoice.Produce.Infrastructure.Helper;
using ElectronicInvoice.Produce.Mapping;
using System.Collections.Generic;
using ElectronicInvoice.Produce.Base;

namespace ElectronicInvoice.Produce
{
    public class CarrierTilteApi : ApiBase<CarrierTilteModel>
    {

        protected override string SetParamter(CarrierTilteModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();
            paramter["version"] = "0.3";
            paramter["action"] = "carrierInvChk";
            paramter["cardType"] = "3J0002";
            paramter["cardNo"] = model.cardNo;
            paramter["expTimeStamp"] = paramterContext.TimeStampMAX;
            paramter["timeStamp"] = paramterContext.TimeStamp;
            paramter["startDate"] = model.startDate;
            paramter["endDate"] = model.endDate;
            paramter["onlyWinningInv"] = model.onlyWinningInv;
            paramter["uuid"] = paramterContext.UUID;
            paramter["cardEncrypt"] = model.cardEncrypt;
            paramter["appID"] = paramterContext.GovAppId;
            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}