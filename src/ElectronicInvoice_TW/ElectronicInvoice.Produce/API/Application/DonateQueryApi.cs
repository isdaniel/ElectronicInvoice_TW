using System.Collections.Generic;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce.API.Application
{
    internal sealed class DonateQueryApi : ApiBase<DonateQueryModel>
    {
        protected override string SetParameter(DonateQueryModel model)
        {
            SortedDictionary<string, string> parameter = new SortedDictionary<string, string>
            {
                ["version"] = model.Version,
                ["qKey"] = model.qKey,
                ["action"] = GetMapperAction,
                ["uuid"] = model.UUID,
                ["appID"] = ConfigSetting.GovAppId
            };
            return ParameterHelper.DictionaryToParameter(parameter);
        }

        public DonateQueryApi(IConfig config, ISysLog log) : base(config, log)
        {
        }
    }
}
