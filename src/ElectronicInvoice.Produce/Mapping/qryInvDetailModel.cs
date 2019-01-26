using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Mapping
{
    [ApiType(ApiType = typeof(qryInvDetailApi))]
    public class qryInvDetailModel : CommonBaseModel
    {
        public string appID { get; set; }
        public string randomNumber { get; set; }
        public string UUID { get; set; }
        public string sellerID { get; set; }
        public string type { get; set; }
        public string invNum { get; set; }
        public string action { get; set; }
        public string generation { get; set; }
        public string invTerm { get; set; }
        public string invDate { get; set; }
        public string encrypt { get; set; }
    }
}