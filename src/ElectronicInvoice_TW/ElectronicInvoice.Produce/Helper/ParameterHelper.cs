using System.Collections.Generic;
using System.Linq;

namespace ElectronicInvoice.Produce.Helper
{
    public class ParameterHelper
    {
        /// <summary>
        /// 將字典轉成相對應參數字串
        /// </summary>
        /// <param name="dirc"></param>
        /// <returns></returns>
        public static string DictionaryToParameter(IDictionary<string,string> dirc)
        {
            return string.Join("&", dirc.Select(x => $"{x.Key}={x.Value}"));
        }
    }
}
