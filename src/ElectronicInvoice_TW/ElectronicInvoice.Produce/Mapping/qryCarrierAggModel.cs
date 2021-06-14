using ElectronicInvoice.Produce.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.API.Application;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Mapping
{
    /// <summary>
    /// 手機條碼歸戶載具查詢
    /// </summary>
    [ApiType(ApiType = typeof(QryCarrierAggApi))]
    public class QryCarrierAggModel : CommonBaseModel
    {

        public string CardNo { get; set; }

        public string CardEncrypt { get; set; }
        public CardType CardType { get; set; }
    }
}
