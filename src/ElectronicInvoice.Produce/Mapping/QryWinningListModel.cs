using ElectronicInvoice.Core.Infrastructure.Attributes;
using ElectronicInvoice.Service;

namespace ElectronicInvoice.Models
{
    [ApiType(ApiType = typeof(QryWinningListApi), MockApiType = typeof(QryWinningListMockApi))]
    public class QryWinningListModel
    {
        public string invTerm { get; set; }
    }
}