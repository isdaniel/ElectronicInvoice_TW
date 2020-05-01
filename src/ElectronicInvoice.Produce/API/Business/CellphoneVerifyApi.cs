using System.Collections.Generic;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce.API.Business
{
    internal sealed class CellphoneVerifyApi : ApiBase<CellphoneVerifyModel>
    {
        protected override string SetParameter(CellphoneVerifyModel model)
        {
            SortedDictionary<string, string> parameter = new SortedDictionary<string, string>
            {
                ["version"] = "0.1",
                ["action"] = GetMapperAction,
                ["barCode"] = model.BarCode,
                ["TxID"] = model.TxID,
                ["appId"] = ConfigSetting.GovAppId
            };

            return ParameterHelper.DictionaryToParameter(parameter);
        }

        public CellphoneVerifyApi(IConfig config, ISysLog log) : base(config, log)
        {
        }
    }
}
