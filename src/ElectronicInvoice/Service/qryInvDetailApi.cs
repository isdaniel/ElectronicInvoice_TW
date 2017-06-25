using ElectronicInvoice.Infrastructure.Helper;
using ElectronicInvoice.Model;
using ElectronicInvoice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicInvoice.Service
{

    public class qryInvDetailApi : ApiBase<qryInvDetailModel>
    {
        protected override string SetParamter(qryInvDetailModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();
            paramter["version"] = "0.3";
            paramter["action"] = "qryInvDetail";
            paramter["invTerm"] = model.invTerm;
            paramter["UUID"] = UUID;
            paramter["type"] = model.type;
            paramter["invNum"] = model.invNum;
            paramter["generation"] = model.generation;
            paramter["invTerm"] = model.invTerm;
            paramter["invDate"] = model.invDate;
            paramter["encrypt"] = model.encrypt;
            paramter["sellerID"] = model.sellerID;
            paramter["randomNumber"] = model.randomNumber;
            paramter["appID"] = GovAppId;
            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}