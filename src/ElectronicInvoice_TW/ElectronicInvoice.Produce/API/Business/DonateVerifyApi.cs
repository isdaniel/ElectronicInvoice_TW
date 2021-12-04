using System.Collections.Generic;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce.API.Business
{
    internal sealed class DonateVerifyApi : ApiBase<DonateVerifyModel>
    {
        protected override string SetParameter(DonateVerifyModel model)
        {
            SortedDictionary<string, string> parameter = new SortedDictionary<string, string>
            {
                ["version"] = model.Version,
                ["action"] = GetMapperAction,
                ["pCode"] = model.PCode,
                ["TxID"] = model.TxID,
                ["appId"] = ConfigSetting.GovAppId
            };

            return ParameterHelper.DictionaryToParameter(parameter);
        }

        internal DonateVerifyApi(IConfig config, ISysLog log) : base(config, log)
        {
        }
    }
}