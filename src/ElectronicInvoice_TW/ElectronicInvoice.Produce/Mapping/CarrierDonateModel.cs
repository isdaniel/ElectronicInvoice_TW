using System;
using ElectronicInvoice.Produce.API.Application;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Mapping
{
    /// <summary>
    /// 載具發票捐贈
    /// </summary>
    [ApiType(ApiType = typeof(CarrierDonateApi))]
    public class CarrierDonateModel : CommonBaseModel
    {
        public CardType CardType { get; set; }
        public string CardNo { get; set; }
        public DateTime InvDate { get; set; }
        public string InvNum { get; set; }
        public string NpoBan { get; set; }
        public string CardEncrypt { get; set; }
        /// <summary>
        /// default value (N) as same as doc
        /// </summary>
        public BuyerType IsBuyerType { get; set; } = BuyerType.N;
    }
}
