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
                ["version"] = model.Version,
                ["action"] = GetMapperAction,
                ["cardType"] = model.CardType.GetCardName(),
                ["cardNo"] = model.CardNo,
                ["expTimeStamp"] = model.TimeStampMAX,
                ["timeStamp"] = model.TimeStamp,
                ["invNum"] = model.InvNum,
                ["invDate"] = model.InvDate,
                ["isBuyerType"] = model.IsBuyerType.ToString(),
                ["page"] = model.Page.ToString(),
                ["uuid"] = model.UUID,
                ["cardEncrypt"] = model.CardEncrypt,
                ["appID"] = ConfigSetting.GovAppId
            };


            return ParameterHelper.DictionaryToParameter(parameter);
        }

        internal CarrierDetailApi(IConfig config, ISysLog log) : base(config, log)
        {
        }
    }
}