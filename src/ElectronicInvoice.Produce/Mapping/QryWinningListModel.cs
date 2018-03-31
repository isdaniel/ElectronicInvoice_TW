using ElectronicInvoice.Produce.Attributes;

namespace ElectronicInvoice.Produce.Mapping
{
    [ApiType(ApiType = typeof(QryWinningListApi), MockApiType = typeof(QryWinningListMockApi))]
    public class QryWinningListModel
    {
        public string invTerm { get; set; }
    }
}