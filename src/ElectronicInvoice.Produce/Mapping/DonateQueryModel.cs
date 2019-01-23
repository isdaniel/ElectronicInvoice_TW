using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Mapping
{
    [ApiType(ApiType = typeof(DonateQueryApi))]
    public class DonateQueryModel : CommonBaseModel
    {
        /// <summary>
        /// 要查詢的捐贈碼/統編之關鍵字
        /// </summary>
        public string qKey { get; set; }
    }
}

