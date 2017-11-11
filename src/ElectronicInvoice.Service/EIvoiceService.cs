using ElectronicInvoice.Core.Facade;
using ElectronicInvoice.Core.Infrastructure.Factroy;
using ElectronicInvoice.Models;
using ElectronicInvoice.Models.InvoiceResult;
using ElectronicInvoice.Produce.Mapping;
using System;
using System.Linq;
using System.Collections.Generic;
using ElectronicInvoice.Models.ViewModel;

namespace ElectronicInvoice.Service
{
    public class EIvoiceService
    {
        private MoblieInvoiceApiFactroy factory = new MoblieInvoiceApiFactroy();

        public QryWinningListViewModel GetWinningList
            (string invTerm)
        {
            QryWinningListModel model = new QryWinningListModel() { invTerm = invTerm };
            var api = factory.GetProxyInstace(model);
            var resultJson = api.ExcuteApi(model);
            var resultModle = JsonConvertFacde.DeserializeObject<QryWinningListViewModel>(resultJson);
            return resultModle;
        }

        public List<InvoiceViewModel> GetInvoice(CarrierTilteModel carrierTitle)
        {
            var api = factory.GetProxyInstace(carrierTitle);
            string result = api.ExcuteApi(carrierTitle);
            var title = JsonConvertFacde.DeserializeObject<CarrierTitle>(result);
            List<InvoiceViewModel> InvoiceList = new List<InvoiceViewModel>();
            if (title.code == "200")
            {
                foreach (var detail in title.details)
                {
                    InvoiceList.Add(new InvoiceViewModel()
                    {
                        InvNum = detail.invNum,
                        TotleAmt = detail.amount
                    });
                    //var model = GetDetail(carrierTitle, detail);
                    //var apiDetail = factory.GetProxyInstace(model);
                    //string resultDetail = apiDetail.ExcuteApi(model);
                    //CarrierDeatail Detail = JsonConvertFacde.DeserializeObject<CarrierDeatail>(resultDetail);
                }
            }
            return InvoiceList;
        }

        private CarrierDetailModel GetDetail(CarrierTilteModel carrierTitle, TitleDetail detail)
        {
            return new CarrierDetailModel()
            {
                invNum = detail.invNum,
                cardNo = detail.cardNo,
                cardEncrypt = carrierTitle.cardEncrypt,
                cardType = "3J0002",
                invDate = $"{Convert.ToInt32(detail.invDate.year) + 1911}/{detail.invDate.month}/{detail.invDate.date}"
            };
        }
    }
}