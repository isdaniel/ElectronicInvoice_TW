using System.Collections.Generic;

namespace ElectronicInvoice.Produce.InvoiceResult
{
    public class InvDate
    {
        public string year { get; set; }
        public string month { get; set; }
        public string date { get; set; }
        public string day { get; set; }
        public string hours { get; set; }
        public string minutes { get; set; }
        public string seconds { get; set; }
        public string time { get; set; }
        public string timezoneOffset { get; set; }
    }

    public class TitleDetail
    {
        public string rowNum { get; set; }
        public string invNum { get; set; }
        public string cardType { get; set; }
        public string cardNo { get; set; }
        public string sellerName { get; set; }
        public string invStatus { get; set; }
        public string invDonatable { get; set; }
        public string amount { get; set; }
        public string invPeriod { get; set; }
        public string sellerBan { get; set; }
        public string sellerAddress { get; set; }
        public string invoiceTime { get; set; }
        public string donateMark { get; set; }
        public InvDate invDate { get; set; }
    }

    public class CarrierTitleResult
    {
        public string v { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
        public string onlyWinningInv { get; set; }
        public List<TitleDetail> details { get; set; }
    }
}