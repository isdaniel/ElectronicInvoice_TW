using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Produce.Mapping
{

    [ApiType(ApiType = typeof(InvoiceTitleApi))]
    public class InvoiceTitleModel : CommonBaseModel
    {
        public InvoiceType Type { get; set; }
        public string InvNum { get; set; }
        public DateTime InvDate { get; set; }
    }

    public class InvoiceTitleReturnModel
    {
        public string invNum { get; set; }
        public string invDate { get; set; }
        public string sellerName { get; set; }
        public string invStatus { get; set; }
        public string invPeriod { get; set; }
        public string sellerBan { get; set; }
        public string invoiceTime { get; set; }
        public string v { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
    }

}
