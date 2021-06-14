using System.Linq.Expressions;
using ElectronicInvoice.Produce.API;
using ElectronicInvoice.Produce.API.Application;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Mapping
{
    /// <summary>
    /// 載具發票明細查詢
    /// </summary>
    [ApiType(ApiType = typeof(CarrierDetailApi))]
    public class CarrierDetailModel : CommonBaseModel
    {
        public CardType CardType { get; set; } 
        public string CardNo { get; set; }
        public string InvNum { get; set; }
        public string InvDate { get; set; }

        public string CardEncrypt { get; set; }
    }
}