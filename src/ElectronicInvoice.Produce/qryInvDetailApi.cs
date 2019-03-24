using ElectronicInvoice.Produce.Infrastructure.Helper;
using ElectronicInvoice.Produce.Mapping;
using System.Collections.Generic;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce
{
    internal sealed class QryInvDetailApi : ApiBase<qryInvDetailModel>
    {

        protected override string SetParameter(qryInvDetailModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();
            paramter["version"] = "0.3";
            paramter["action"] = ActionParameter.QryInvDetailApi;
            paramter["invTerm"] = model.invTerm;
            paramter["UUID"] = model.UUID;
            paramter["type"] = model.type;
            paramter["invNum"] = model.invNum;
            paramter["generation"] = model.generation;
            paramter["invTerm"] = model.invTerm;
            paramter["invDate"] = model.invDate;
            paramter["encrypt"] = model.encrypt;
            paramter["sellerID"] = model.sellerID;
            paramter["randomNumber"] = model.randomNumber;
            paramter["appID"] = ConfigSetting.GovAppId;
            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}