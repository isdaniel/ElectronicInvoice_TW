using ElectronicInvoice.Core.Facade;
using ElectronicInvoice.Produce.Mapping;
using System;
using System.Collections.Generic;
using ElectronicInvoice.Models.ViewModel;
using ElectronicInvoice.Core.ConfigSetting;
using AutoMapper;
using ElectronicInvoice.Produce.Factroy;
using ElectronicInvoice.Produce.InvoiceResult;
using Autofac;
using ElectronicInvoice.Produce.Base;

namespace ElectronicInvoice.Service
{
    public class EIvoiceService
    {
        private static IMapper mapper = MapperSetting.Current.Setting;
        private static IContainer autofac = AutofacConfig.Register();
        /// <summary>
        /// 取得中獎號碼
        /// </summary>
        /// <param name="invTerm">查詢的期別</param>
        /// <returns></returns>
        public QryWinningListResultViewModel GetWinningList(QryWinningListViewModel viewModel)
        {
            var model = mapper.Map<QryWinningListModel>(viewModel);
            var resultJson = ExcuteApi(model);
            return JsonConvertFacde.DeserializeObject<QryWinningListResultViewModel>(resultJson);
        }

        public List<InvoiceViewModel> GetInvoice(CarrierTilteViewModel viewModel)
        {
            var carrierTitleModel = mapper.Map<CarrierTilteModel>(viewModel);
            string result = ExcuteApi(carrierTitleModel);
            var title = JsonConvertFacde.DeserializeObject<CarrierTitleResult>(result);
            List<InvoiceViewModel> InvoiceList = null;
            //查詢成功再加入List中
            if (title.code == "200")
            {
                InvoiceList = mapper.Map<List<InvoiceViewModel>>(title.details);
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

        /// <summary>
        /// 執行API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="carrierTitleModel"></param>
        /// <returns></returns>
        private string ExcuteApi<T>(T carrierTitleModel) where T :
            class, new()
        {
            InvoiceApiFactroy factory;
            IConfig config;
            using (var container = autofac.BeginLifetimeScope())
            {
                config = container.Resolve<IConfig>();
                factory = container.Resolve<InvoiceApiFactroy>();
            }
            var api = factory.GetProxyInstace(carrierTitleModel);
            return api.ExcuteApi(carrierTitleModel);
        }
    }
}