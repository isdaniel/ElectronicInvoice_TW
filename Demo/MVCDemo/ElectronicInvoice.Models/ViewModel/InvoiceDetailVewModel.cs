using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Models.ViewModel
{
    public class InvoiceDetailVewModel
    {
        /// <summary>
        /// 商品描述
        /// </summary>
        [Display(Name = "商品描述")]
        public string description { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        [Display(Name = "數量")]
        public string quantity { get; set; }

        /// <summary>
        /// 單價
        /// </summary>
        [Display(Name = "單價")]
        public string unitPrice { get; set; }

        /// <summary>
        /// 小計
        /// </summary>
        [Display(Name = "小計")]
        public string amount { get; set; }
    }
}