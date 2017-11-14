using ElectronicInvoice.Produce.Attributes;

namespace ElectronicInvoice.Produce.Mapping
{
    [ApiType(ApiType = typeof(CarrierDetailApi))]
    public class CarrierDetailModel
    {
        public string cardType { get; set; }
        public string cardNo { get; set; }
        public string invNum { get; set; }
        public string invDate { get; set; }

        public string cardEncrypt { get; set; }
    }
}