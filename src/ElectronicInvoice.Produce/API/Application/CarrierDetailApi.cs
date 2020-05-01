using System.Collections.Generic;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Extension;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce.API.Application
{
    internal sealed class CarrierDetailApi : ApiBase<CarrierDetailModel>
    {

        protected override string SetParameter(CarrierDetailModel model)
        {
            SortedDictionary<string, string> parameter = new SortedDictionary<string, string>
            {
                ["version"] = "0.3",
                ["action"] = GetMapperAction,
                ["cardType"] = model.CardType.GetCardName(),
                ["cardNo"] = model.CardNo,
                ["expTimeStamp"] = model.TimeStampMAX,
                ["timeStamp"] = model.TimeStamp,
                ["invNum"] = model.InvNum,
                ["invDate"] = model.InvDate,
                ["uuid"] = model.UUID,
                ["cardEncrypt"] = model.CardEncrypt,
                ["appID"] = ConfigSetting.GovAppId
            };


            return ParameterHelper.DictionaryToParameter(parameter);
        }

        public CarrierDetailApi(IConfig config, ISysLog log) : base(config, log)
        {
        }
    }
}