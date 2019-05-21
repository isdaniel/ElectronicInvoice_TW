using ElectronicInvoice.Models.ViewModel;
using ElectronicInvoice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;

namespace ElectronicInvoice.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }


        public ActionResult QryWinningList()
        {
            QryWinningListViewModel viewModel = new QryWinningListViewModel() { invTerm = "10406" };
            var resultModel = _invoiceService .GetWinningList(viewModel);
            return View(resultModel);
        }

        public ActionResult qryInvDetail()
        {
            return View();
        }

        public ActionResult CarrierTitle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CarrierTitle(CarrierTilteViewModel model)
        {
            var result = _invoiceService.GetInvoice(model);
            return View("CarrierTitleResult", result);
        }

        //[HttpPost]
        //public ActionResult qryInvDetail()
        //{
        //    return View();
        //    //var api = factory.GetInstace(model);
        //    //var result = api.ExcuteApi(model);
        //    //return Content(result);
        //}
    }
}