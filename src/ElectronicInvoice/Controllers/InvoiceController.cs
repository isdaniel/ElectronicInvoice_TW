using ElectronicInvoice.Infrastructure.Factroy;
using ElectronicInvoice.Model;
using ElectronicInvoice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicInvoice.Controllers
{
    public class InvoiceController : Controller
    {
        public ActionResult QryWinningList()
        {
            QryWinningListModel model = new QryWinningListModel()
            {
                invTerm = "10604"
            };
            MoblieInvoiceApiFactroy.GetInstanceType(model);
            var api = MoblieInvoiceApiFactroy.GetInstace(model);
            var resultJson = api.ExcuteApi(model);
            var resultModle = JsonConvert.DeserializeObject<QryWinningListViewModel>(resultJson);
            return View(resultModle);
        }

        public ActionResult qryInvDetail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult qryInvDetail(qryInvDetailModel model)
        {
            var api = MoblieInvoiceApiFactroy.GetInstace(model);
            var result = api.ExcuteApi(model);
            return Content(result);
        }
    }
}