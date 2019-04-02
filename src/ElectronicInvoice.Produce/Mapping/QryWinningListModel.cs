using ElectronicInvoice.Produce.API.Application;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Mapping
{
    /// <summary>
    /// 查詢中獎發票號碼清單
    /// </summary>
    [ApiType(ApiType = typeof(QryWinningListApi), MockApiType = typeof(QryWinningListMockApi))]
    public class QryWinningListModel : CommonBaseModel
    {
        public string invTerm { get; set; }
    }
}