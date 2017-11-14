using ElectronicInvoice.Produce.Facade;
using ElectronicInvoice.Produce.Infrastructure.Helper;
using ElectronicInvoice.Service.Base;
using System.Collections.Generic;
using ElectronicInvoice.Produce.InvoiceResult;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce
{
    /// <summary>
    /// 連接財政部API
    /// </summary>
    public class QryWinningListApi : ApiBase<QryWinningListModel>
    {
        protected override string SetParamter(QryWinningListModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();
            paramter["version"] = "0.2";
            paramter["action"] = "QryWinningList";
            paramter["invTerm"] = model.invTerm;
            paramter["UUID"] = paramterContext.UUID;
            paramter["appID"] = paramterContext.GovAppId;
            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }

    /// <summary>
    /// 當出現意外狀況時可以讀取的資料
    /// </summary>
    public class QryWinningListMockApi : ApiBase<QryWinningListModel>
    {
        protected override string SetParamter(QryWinningListModel model)
        {
            return string.Empty;
        }

        public override string ExcuteApi(QryWinningListModel model)
        {
            //這裡可以讀取DB的資料 我偷懶所以寫死資料
            QryWinningListResult MockResult = new QryWinningListResult()
            {
                code = "200",
                msg = "OK",
                firstPrizeNo1 = "1234",
                firstPrizeNo10 = "123345"
            };
            return JsonConvertFacde.SerializeObject(MockResult);
        }
    }
}