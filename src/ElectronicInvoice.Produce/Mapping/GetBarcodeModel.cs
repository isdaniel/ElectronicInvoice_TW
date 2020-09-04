using System.Security.AccessControl;
using ElectronicInvoice.Produce.API.Business;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Mapping
{
    [ApiType(ApiType = typeof(GetBarcodeApi))]
    public class GetBarcodeModel: CommonBaseModel
    {
        public string PhoneNo { get; set; }
        public string VerificationCode{ get; set; }
    }
}