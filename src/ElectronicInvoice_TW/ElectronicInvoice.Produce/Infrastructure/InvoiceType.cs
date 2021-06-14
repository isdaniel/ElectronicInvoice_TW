

using ElectronicInvoice.Produce.Attributes;

namespace ElectronicInvoice.Produce.Infrastructure
{
    public enum InvoiceType
    {
        Barcode,
        QRCode
    }

    public enum OnlyWinningInvType
    {
        [Content(Name = "Y")]
        Y,
        [Content(Name = "N")]
        N
    }

    public enum CardType
    {
        [Content(Name = "3J0002")]
        PhoneBarCode
    }
}