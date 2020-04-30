using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Infrastructure;
using System;
using ElectronicInvoice.Produce.API;
using ElectronicInvoice.Produce.API.Application;

namespace ElectronicInvoice.Produce.Mapping
{    
    /// <summary>
    /// 查詢發票明細
    /// </summary>
    [ApiType(ApiType = typeof(InvoiceDetailApi))]
    public class InvoiceDetailModel : CommonBaseModel
    {
        public InvoiceType Type { get; set; }
        public string InvNum { get; set; }
        /// <summary>
        /// Type 為 Barcode時為必填
        /// </summary>
        public string InvTerm { get; set; }
        public DateTime InvDate { get; set; }
        /// <summary>
        /// Type為 QRCode時為必填
        /// </summary>
        public string Encrypt { get; set; }
        /// <summary>
        /// Type為 QRCode時為必填
        /// </summary>
        public string SellerID { get; set; }

        public string RandomNumber { get; set; }
        public string Version { get; set; } = "0.5";
    }
}
