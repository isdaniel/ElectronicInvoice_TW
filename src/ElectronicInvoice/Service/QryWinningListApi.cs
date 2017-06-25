using ElectronicInvoice.Infrastructure.Helper;
using ElectronicInvoice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicInvoice.Service
{

    public class QryWinningListApi : ApiBase<QryWinningListModel>
    {
        protected override string SetParamter(QryWinningListModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();
            paramter["version"] = "0.2";
            paramter["action"] = "QryWinningList";
            paramter["invTerm"] = model.invTerm;
            paramter["UUID"] = UUID;
            paramter["appID"] = GovAppId;
            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}