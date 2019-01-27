using ElectronicInvoice.Produce.Infrastructure.Helper;
using ElectronicInvoice.Produce.Mapping;
using System.Collections.Generic;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce
{
    internal sealed class CarrierTilteApi : ApiBase<CarrierTilteModel>
    {

        protected override string SetParamter(CarrierTilteModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();
            paramter["version"] = "0.3";
            paramter["action"] = ActionParameter.CarrierTilteApi;
            paramter["cardType"] = "3J0002";
            paramter["cardNo"] = model.cardNo;
            paramter["expTimeStamp"] = model.TimeStampMAX;
            paramter["timeStamp"] = model.TimeStamp;
            paramter["startDate"] = model.startDate;
            paramter["endDate"] = model.endDate;
            paramter["onlyWinningInv"] = model.onlyWinningInv;
            paramter["uuid"] = model.UUID;
            paramter["cardEncrypt"] = model.cardEncrypt;
            paramter["appID"] = _config.GovAppId;
            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}