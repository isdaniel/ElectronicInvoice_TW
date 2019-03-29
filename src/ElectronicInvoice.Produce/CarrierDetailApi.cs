using ElectronicInvoice.Produce.Mapping;
using System.Collections.Generic;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce
{
    internal sealed class CarrierDetailApi : ApiBase<CarrierDetailModel>
    {

        protected override string SetParameter(CarrierDetailModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();

            paramter["version"] = "0.3";
            paramter["action"] = ActionParameter.CarrierDetailApi;
            paramter["cardType"] = "3J0002";
            paramter["cardNo"] = model.cardNo;
            paramter["expTimeStamp"] = model.TimeStampMAX;
            paramter["timeStamp"] = model.TimeStamp;
            paramter["invNum"] = model.invNum;
            paramter["invDate"] = model.invDate;
            paramter["uuid"] = model.UUID;
            paramter["cardEncrypt"] = model.cardEncrypt;
            paramter["appID"] = ConfigSetting.GovAppId;

            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}