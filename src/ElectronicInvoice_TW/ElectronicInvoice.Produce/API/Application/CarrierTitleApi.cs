using System.Collections.Generic;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Extension;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce.API.Application
{
    internal sealed class CarrierTitleApi : ApiBase<CarrierTitleModel>
    {

        protected override string SetParameter(CarrierTitleModel model)
        {
            SortedDictionary<string, string> parameter = new SortedDictionary<string, string>
            {
                ["version"] = model.Version,
                ["action"] = GetMapperAction,
                ["cardType"] = model.CardType.GetAttributeValue<ContentAttribute,string>(x=> x.Name),
                ["cardNo"] = model.CardNo,
                ["expTimeStamp"] = model.TimeStampMAX,
                ["timeStamp"] = model.TimeStamp,
                ["startDate"] = model.StartDate.ToString("yyyy/MM/dd"),
                ["endDate"] = model.EndDate.ToString("yyyy/MM/dd"),
                ["onlyWinningInv"] = model.OnlyWinningInv.ToString(),
                ["uuid"] = model.UUID,
                ["cardEncrypt"] = model.CardEncrypt,
                ["appID"] = ConfigSetting.GovAppId
            };
            return ParameterHelper.DictionaryToParameter(parameter);
        }

        public CarrierTitleApi(IConfig config, ISysLog log) : base(config, log)
        {
        }
    }
}