using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Models.ViewModel
{
    public class CarrierTilteViewModel
    {
        public string cardNo { get; set; }

        public string startDate { get; set; }
        public string endDate { get; set; }
        public string onlyWinningInv { get; set; }

        public string cardEncrypt { get; set; }
    }
}