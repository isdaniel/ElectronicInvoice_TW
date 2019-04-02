using System.Collections.Generic;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce.API.Application
{
    internal sealed class QryInvDetailApi : ApiBase<qryInvDetailModel>
    {

        protected override string SetParameter(qryInvDetailModel model)
        {
            SortedDictionary<string, string> parameter = new SortedDictionary<string, string>
            {
                ["version"] = "0.3",
                ["action"] = ActionParameter.QryInvDetailApi,
                ["invTerm"] = model.InvTerm,
                ["UUID"] = model.UUID,
                ["type"] = model.type,
                ["InvNum"] = model.invNum,
                ["generation"] = model.generation,
                ["invTerm"] = model.InvTerm,
                ["invDate"] = model.invDate,
                ["encrypt"] = model.encrypt,
                ["sellerID"] = model.sellerID,
                ["randomNumber"] = model.randomNumber,
                ["appID"] = ConfigSetting.GovAppId
            };
            return ParameterHelper.DictionaryToParameter(parameter);
        }
    }
}