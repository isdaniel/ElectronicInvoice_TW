using System;
using System.Collections.Generic;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Extension;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce.API.Application
{
    internal sealed class QryCarrierAggApi : ApiBase<QryCarrierAggModel>
    {
        protected override string SetParameter(QryCarrierAggModel model)
        {
            SortedDictionary<string, string> parameter = new SortedDictionary<string, string>
            {
                ["version"] = model.Version,
                ["serial"] = model.Serial,
                ["action"] = GetMapperAction,
                ["cardType"] = model.CardType.GetCardName(),
                ["cardNo"] = model.CardNo,
                ["cardEncrypt"] = model.CardEncrypt,
                ["timeStamp"] = model.TimeStamp,
                ["uuid"] = model.UUID,
                ["appID"] = ConfigSetting.GovAppId
            };

            return ParameterHelper.DictionaryToParameter(parameter);
        }

        internal QryCarrierAggApi(IConfig config, ISysLog log) : base(config, log)
        {
        }
    }
}
