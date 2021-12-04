using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Extension;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce.API.Application
{
    internal sealed class CarrierDonateApi : ApiBase<CarrierDonateModel>
    {
        protected override string SetParameter(CarrierDonateModel model)
        {
            SortedDictionary<string, string> parameter = new SortedDictionary<string, string>
            {
                ["version"] = model.Version,
                ["serial"] =  model.Serial,
                ["action"] = GetMapperAction,
                ["cardType"] = model.CardType.GetCardName(),
                ["cardNo"] = model.CardNo,
                ["expTimeStamp"] = model.TimeStampMAX,
                ["timeStamp"] = model.TimeStamp,
                ["invNum"] = model.InvNum,
                ["invDate"] = model.InvDate.ToString("yyyy/MM/dd"),
                ["uuid"] = model.UUID,
                ["cardEncrypt"] = model.CardEncrypt,
                ["npoBan"] = model.NpoBan,
                ["appID"] = ConfigSetting.GovAppId
            };

            return ParameterHelper.DictionaryToParameter(parameter);

        }

        internal CarrierDonateApi(IConfig config, ISysLog log) : base(config, log)
        {
        }
    }
}
