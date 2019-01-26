using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Mapping
{
    [ApiType(ApiType = typeof(CarrierTilteApi))]
    public class CarrierTilteModel : CommonBaseModel
    {
        public string cardNo { get; set; }

        public string startDate { get; set; }
        public string endDate { get; set; }
        public string onlyWinningInv { get; set; }

        public string cardEncrypt { get; set; }
    }
}