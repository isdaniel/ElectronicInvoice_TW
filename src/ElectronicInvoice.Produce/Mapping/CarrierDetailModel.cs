using ElectronicInvoice.Core.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Produce.Mapping
{
    [ApiType(ApiType = typeof(CarrierDetailApi))]
    public class CarrierDetailModel
    {
        public string cardType { get; set; }
        public string cardNo { get; set; }
        public string invNum { get; set; }
        public string invDate { get; set; }

        public string cardEncrypt { get; set; }
    }
}