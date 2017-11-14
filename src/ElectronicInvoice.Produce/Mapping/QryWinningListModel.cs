using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Service;

namespace ElectronicInvoice.Produce.Mapping
{
    [ApiType(ApiType = typeof(QryWinningListApi), MockApiType = typeof(QryWinningListMockApi))]
    public class QryWinningListModel
    {
        public string invTerm { get; set; }
    }
}