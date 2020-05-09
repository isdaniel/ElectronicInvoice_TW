using System;
using System.Collections.Generic;
using ElectronicInvoice.Produce.Infrastructure;
using Newtonsoft.Json;

namespace ElectronicInvoice.Produce.InvoiceResult
{
   public partial class CarrierTitleResult
    {
        [JsonProperty("v")]
        public string V { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("onlyWinningInv")]
        public string OnlyWinningInv { get; set; }

        [JsonProperty("details")]
        public IEnumerable<TitleDetail> Details { get; set; }
    }

    public class TitleDetail
    {
        [JsonProperty("rowNum")]
        public int RowNum { get; set; }

        [JsonProperty("invNum")]
        public string InvNum { get; set; }

        [JsonProperty("cardType")]
        public string CardType { get; set; }

        [JsonProperty("cardNo")]
        public string CardNo { get; set; }

        [JsonProperty("sellerName")]
        public string SellerName { get; set; }

        [JsonProperty("invStatus")]
        public string InvStatus { get; set; }

        [JsonProperty("invDonatable")]
        public bool InvDonatable { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("invPeriod")]
        public string InvPeriod { get; set; }

        [JsonProperty("sellerBan")]
        public string SellerBan { get; set; }

        [JsonProperty("sellerAddress")]
        public string SellerAddress { get; set; }

        [JsonProperty("invoiceTime")]
        public DateTime InvoiceTime { get; set; }

        [JsonProperty("donateMark")]
        public long DonateMark { get; set; }

        [JsonProperty("invDate")]
        public InvDate InvDate { get; set; }
    }

    public partial class InvDate
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("month")]
        public int Month { get; set; }

        [JsonProperty("date")]
        public int Date { get; set; }

        [JsonProperty("day")]
        public int Day { get; set; }

        [JsonProperty("hours")]
        public int Hours { get; set; }

        [JsonProperty("minutes")]
        public int Minutes { get; set; }

        [JsonProperty("seconds")]
        public int Seconds { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("timezoneOffset")]
        public long TimezoneOffset { get; set; }

        public DateTime InvDateTime {
            get
            {
                return new DateTime(Year,Month,Date);
            }
        }
    }
}