using System.Linq.Expressions;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Mapping
{
    [ApiType(ApiType = typeof(CarrierDetailApi))]
    public class CarrierDetailModel
    {
        public CommonProperty CommonProp { get;  } = new CommonProperty();
        public string cardType { get; set; }
        public string cardNo { get; set; }
        public string invNum { get; set; }
        public string invDate { get; set; }

        public string cardEncrypt { get; set; }
    }
}