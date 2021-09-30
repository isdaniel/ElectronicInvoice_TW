using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Mapping
{
    public class CellphoneVerifyModel : CommonBaseModel
    {
        public string BarCode { get; set; }
        public string TxID { get; set; }
    }
}