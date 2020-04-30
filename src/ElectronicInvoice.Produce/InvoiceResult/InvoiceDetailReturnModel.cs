using Newtonsoft.Json;
using System;

namespace ElectronicInvoice.Produce.InvoiceResult
{
    public partial class InvoiceDetailReturnModel
    {
        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("invNum")]
        public string InvNum { get; set; }

        [JsonProperty("invoiceTime")]
        public DateTime InvoiceTime { get; set; }

        [JsonProperty("invStatus")]
        public string InvStatus { get; set; }

        [JsonProperty("sellerName")]
        public string SellerName { get; set; }

        [JsonProperty("invPeriod")]
        public string InvPeriod { get; set; }

        [JsonProperty("sellerAddress")]
        public string SellerAddress { get; set; }

        [JsonProperty("sellerBan")]
        public string SellerBan { get; set; }

        [JsonProperty("buyerBan")]
        public string BuyerBan { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("details")]
        public Detail[] Details { get; set; }

        [JsonProperty("invDate")]
        public string InvDate { get; set; }
    }

    public class Detail
    {
        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("rowNum")]
        public int RowNum { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}