using System.Collections.Generic;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Facade;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.InvoiceResult;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce.API.Application
{
    /// <summary>
    /// 連接財政部API
    /// </summary>
    internal sealed class QryWinningListApi : ApiBase<QryWinningListModel>
    {

        protected override string SetParameter(QryWinningListModel model)
        {
            SortedDictionary<string, string> parameter = new SortedDictionary<string, string>
            {
                ["version"] = model.Version,
                ["action"] = GetMapperAction,
                ["invTerm"] = model.invTerm,
                ["UUID"] = model.UUID,
                ["appID"] = ConfigSetting.GovAppId
            };
            return ParameterHelper.DictionaryToParameter(parameter);
        }

        internal QryWinningListApi(IConfig config, ISysLog log) : base(config, log)
        {
        }
    }
}