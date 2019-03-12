using System.Collections.Generic;
using ElectronicInvoice.Models.ViewModel;

namespace ElectronicInvoice.Service
{
    public interface IInvoiceService
    {
        List<InvoiceViewModel> GetInvoice(CarrierTilteViewModel viewModel);
        QryWinningListResultViewModel GetWinningList(QryWinningListViewModel viewModel);
    }
}