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
            string value = string.Empty;
            List<string> paraList = new List<string>();
            foreach (var item in dirc)
            {
                value = item.Value ?? "";
                paraList.Add(SpellParamter(item.Key, value));
            }
            return string.Join("&", paraList);
        }

        private static string SpellParamter(string key,string value) {
            return $"{key}={value}";
        }
    }
}