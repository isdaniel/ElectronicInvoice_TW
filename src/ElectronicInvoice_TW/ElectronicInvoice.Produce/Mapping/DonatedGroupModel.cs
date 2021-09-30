using System;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Mapping
{
    public class DonatedGroupModel : CommonBaseModel
    {
        public string Ban { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public DateTime InvoiceYmE { get; set; }
        public DateTime InvoiceYmS { get; set; }
        public string HsnNm { get; set; }
        public string BusiChiNm { get; set; }
        public string CardTypeNm { get; set; }
        public string CardCodeNm { get; set; }
    }
}