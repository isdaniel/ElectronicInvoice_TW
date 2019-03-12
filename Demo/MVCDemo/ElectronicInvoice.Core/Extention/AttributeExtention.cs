using System;
using System.Linq;

namespace ElectronicInvoice.Core.Extension
{
    public static class ExtensionAttribute
    {
        public static TValue GetAttributeValue<TAttribute, TValue>(
          this Type attrType,
          Func<TAttribute, TValue> selecotr) where TAttribute : Attribute
        {
            var attr = attrType.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            if (attr != null)
            {
                return selecotr(attr);
            }
            return default(TValue);
        }
    }
}