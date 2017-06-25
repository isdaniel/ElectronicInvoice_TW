using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ElectronicInvoice.Infrastructure.Helper
{
    public class PraramterHelper
    {
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

        public static string SpellParamter(string key,string value) {
            return $"{key}={value}";
        }
    }
}