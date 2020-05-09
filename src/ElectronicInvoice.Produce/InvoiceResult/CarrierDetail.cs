using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ElectronicInvoice.Produce.InvoiceResult
{
    public class CarrierDetailResult
    {
        [JsonProperty("v")]
        public string V { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("invNum")]
        public string InvNum { get; set; }

        [JsonProperty("invDate")]
        public string InvDate { get; set; }

        [JsonProperty("sellerName")]
        public string SellerName { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("invStatus")]
        public string InvStatus { get; set; }

        [JsonProperty("invPeriod")]
        public string InvPeriod { get; set; }

        [JsonProperty("details")]
        public IEnumerable<DetailCarrier> Details { get; set; }

        [JsonProperty("sellerBan")]
        public string SellerBan { get; set; }

        [JsonProperty("sellerAddress")]
        public string SellerAddress { get; set; }

        [JsonProperty("invoiceTime")]
        public DateTime InvoiceTime { get; set; }
    }

    public class DetailCarrier
    {
        [JsonProperty("rowNum")]
        public int RowNum { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}