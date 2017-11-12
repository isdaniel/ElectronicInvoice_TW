using ElectronicInvoice.Core.Facade;
using ElectronicInvoice.Core.Infrastructure.Factroy;
using ElectronicInvoice.Models;
using ElectronicInvoice.Models.InvoiceResult;
using ElectronicInvoice.Produce.Mapping;
using System;
using System.Linq;
using System.Collections.Generic;
using ElectronicInvoice.Models.ViewModel;
using ElectronicInvoice.Core.ConfigSetting;

namespace ElectronicInvoice.Service
{
    public class EIvoiceService
    {
        private MoblieInvoiceApiFactroy factory = new MoblieInvoiceApiFactroy();

        /// <summary>
        /// 取得中獎號碼
        /// </summary>
        /// <param name="invTerm">查詢的期別</param>
        /// <returns></returns>
        public QryWinningListViewModel GetWinningList(string invTerm)
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
            List<InvoiceViewModel> InvoiceList = null;
            //查詢成功再加入List中
            if (title.code == "200")
            {
                InvoiceList = MapperSetting.Setting().Map<List<InvoiceViewModel>>(title.details);
            }
            return InvoiceList ?? new List<InvoiceViewModel>();
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