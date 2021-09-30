using System.Collections.Generic;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce.API.Business
{
    internal sealed class DonatedGroupApi : ApiBase<DonatedGroupModel>
    {
        protected override string SetParameter(DonatedGroupModel model)
        {
            SortedDictionary<string, string> parameter = new SortedDictionary<string, string>
            {
                ["version"] = model.Version,
                ["appID"] = ConfigSetting.GovAppId,
                ["ban"] = model.Ban,
                ["account"] = model.Account,
                ["password"] = model.Password,
                ["invoiceYmS"] = model.InvoiceYmS.ToString("yyyyMM"),
                ["invoiceYmE"] = model.InvoiceYmE.ToString("yyyyMM"),
                ["hsnNm"] = model.HsnNm,
                ["busiChiNm"] = model.BusiChiNm,
                ["cardTypeNm"] = model.CardTypeNm,
                ["cardCodeNm"] = model.CardCodeNm
            };

            return ParameterHelper.DictionaryToParameter(parameter);
        }

        public DonatedGroupApi(IConfig config, ISysLog log) : base(config, log)
        {
        }
    }
}