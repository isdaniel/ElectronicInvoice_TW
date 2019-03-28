using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ElectronicInvoice.Produce.Infrastructure.Helper
{
    public class PraramterHelper
    {
        /// <summary>
        /// 將字典轉成相對應參數字串
        /// </summary>
        /// <param name="dirc"></param>
        /// <returns></returns>
        public static string DictionaryToParamter(IDictionary<string,string> dirc)
        {
            return string.Join("&", dirc.Select(x => $"{x.Key}={x.Value}"));
        }
    }
}
