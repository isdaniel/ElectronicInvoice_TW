using System.Collections.Generic;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce.API.Application
{
    internal sealed class InvoiceDetailApi : ApiBase<InvoiceDetailModel>
    {
        protected override string SetParameter(InvoiceDetailModel model)
        {
            SortedDictionary<string, string> parameter = new SortedDictionary<string, string>
            {
                ["version"] = model.Version,
                ["type"] = model.Type.ToString(),
                ["invNum"] = model.InvNum,
                ["action"] = GetMapperAction,
                ["generation"] = "V2",
                ["invTerm"] = model.InvTerm,
                ["invDate"] = model.InvDate.ToString("yyyy/MM/dd"),
                ["encrypt"] = model.Encrypt,
                ["sellerID"] = model.SellerID,
                ["randomNumber"] = model.RandomNumber,
                ["UUID"] = model.UUID,
                ["appID"] = ConfigSetting.GovAppId
            };

            return ParameterHelper.DictionaryToParameter(parameter);
        }

        public InvoiceDetailApi(IConfig config, ISysLog log) : base(config, log)
        {
        }
    }
}
