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
                ["version"] = "0.2",
                ["action"] = ActionParameter.QryWinningListApi,
                ["invTerm"] = model.invTerm,
                ["UUID"] = model.UUID,
                ["appID"] = ConfigSetting.GovAppId
            };
            return ParameterHelper.DictionaryToParameter(parameter);
        }
    }

    /// <summary>
    /// 當出現意外狀況時可以讀取的資料
    /// </summary>
    internal sealed class QryWinningListMockApi : ApiBase<QryWinningListModel>
    {
        protected override string SetParameter(QryWinningListModel model)
        {
            return string.Empty;
        }

        public override string ExecuteApi(QryWinningListModel model)
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