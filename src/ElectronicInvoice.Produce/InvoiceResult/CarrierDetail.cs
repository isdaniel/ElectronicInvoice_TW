using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Produce.InvoiceResult
{
    public class EnvoiceDetail
    {
        public string rowNum { get; set; }
        public string description { get; set; }
        public string quantity { get; set; }
        public string unitPrice { get; set; }
        public string amount { get; set; }
    }

    public class CarrierDeatailResult
    {
        public string v { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
        public string invNum { get; set; }
        public string invDate { get; set; }
        public string sellerName { get; set; }
        public string amount { get; set; }
        public string invStatus { get; set; }
        public string invPeriod { get; set; }
        public string sellerBan { get; set; }
        public string sellerAddress { get; set; }
        public string invoiceTime { get; set; }
        public IEnumerable<EnvoiceDetail> Detail { get; set; }
    }
}