using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Mapping
{
    public class DonateVerifyModel : CommonBaseModel
    {
        public string PCode { get; set; }
        public string TxID { get; set; }
    }
}