using ElectronicInvoice.Produce.Infrastructure.Helper;
using ElectronicInvoice.Produce.Mapping;
using ElectronicInvoice.Service.Base;
using System.Collections.Generic;

namespace ElectronicInvoice.Produce
{
    public class qryInvDetailApi : ApiBase<qryInvDetailModel>
    {
        protected override string SetParamter(qryInvDetailModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();
            paramter["version"] = "0.3";
            paramter["action"] = "qryInvDetail";
            paramter["invTerm"] = model.invTerm;
            paramter["UUID"] = paramterContext.UUID;
            paramter["type"] = model.type;
            paramter["invNum"] = model.invNum;
            paramter["generation"] = model.generation;
            paramter["invTerm"] = model.invTerm;
            paramter["invDate"] = model.invDate;
            paramter["encrypt"] = model.encrypt;
            paramter["sellerID"] = model.sellerID;
            paramter["randomNumber"] = model.randomNumber;
            paramter["appID"] = paramterContext.GovAppId;
            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}