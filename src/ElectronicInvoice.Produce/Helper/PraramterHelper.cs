using System.Collections.Generic;

namespace ElectronicInvoice.Produce.Helper
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
