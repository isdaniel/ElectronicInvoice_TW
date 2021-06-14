using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.API.Application;

namespace ElectronicInvoice.Produce.Mapping
{
    /// <summary>
    /// 查詢發票表頭
    /// </summary>
    [ApiType(ApiType = typeof(InvoiceTitleApi))]
    public class InvoiceTitleModel : CommonBaseModel
    {
        public InvoiceType Type { get; set; }
        public string InvNum { get; set; }
        public DateTime InvDate { get; set; }
        public string Version { get; set; } = "0.5";
    }
}
