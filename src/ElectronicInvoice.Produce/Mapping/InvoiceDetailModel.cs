using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Infrastructure;
using System;

namespace ElectronicInvoice.Produce.Mapping
{
    [ApiType(ApiType = typeof(InvoiceDetailApi))]
    public class InvoiceDetailModel
    {
        public InvoiceType Type { get; set; }
        public string InvNum { get; set; }
        //public string action { get; set; }
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
    }
}
