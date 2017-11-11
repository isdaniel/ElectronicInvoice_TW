using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Models.ViewModel
{
    public class InvoiceViewModel
    {
        [Display(Name = "發票號碼")]
        public string InvNum { get; set; }

        [Display(Name = "總金額")]
        public string TotleAmt { get; set; }

        public IEnumerable<InvoiceDetailVewModel> Detail { get; set; }
    }
}