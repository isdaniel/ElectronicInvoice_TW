using ElectronicInvoice.Produce.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Mapping
{
    [ApiType(ApiType = typeof(QryCarrierAggApi))]
    public class qryCarrierAggModel
    {

        public string cardNo { get; set; }

        public string cardEncrypt { get; set; }
        public CommonProperty CommonProp { get; } = new CommonProperty();
    }
}
