using System;
using ElectronicInvoice.Produce.API;
using ElectronicInvoice.Produce.API.Application;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Mapping
{
    /// <summary>
    /// 載具發票表頭查詢
    /// </summary>
    [ApiType(ApiType = typeof(CarrierTitleApi))]
    public class CarrierTitleModel : CommonBaseModel
    {
        public string CardNo { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public OnlyWinningInvType OnlyWinningInv { get; set; } = OnlyWinningInvType.Y;

        public string CardEncrypt { get; set; }
        public CardType CardType { get; set; }
    }
}