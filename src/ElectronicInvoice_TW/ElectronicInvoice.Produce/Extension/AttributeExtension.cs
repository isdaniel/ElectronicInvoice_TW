using System;
using System.Linq;
using System.Reflection;

namespace ElectronicInvoice.Produce.Extension
{
    public static class AttributeExtension
    {
        public static TValue GetAttributeValue<TAttribute, TValue>(
          this Type attrType,
          Func<TAttribute, TValue> selector) where TAttribute : Attribute
        {
            var attr = attrType.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            if (attr != null)
            {
                return selector(attr);
            }
            return default(TValue);
        }

        public static TValue GetAttributeValue<TAttribute, TValue>(
            this FieldInfo field,
            Func<TAttribute, TValue> selector)
            where TAttribute : Attribute
        {
            TAttribute attr = Attribute.GetCustomAttribute(field, typeof(TAttribute)) as TAttribute;
            return GetValueOrDefault(selector, attr);
        }

        private static TValue GetValueOrDefault<TAttribute, TValue>
            (Func<TAttribute, TValue> selector, TAttribute attr)
            where TAttribute : Attribute
        {
            if (attr != null)
            {
                return selector(attr);
            }

            return default(TValue);
        }

        /// <summary>
        /// 取得Enum 欄位的Attribute
        /// </summary>
        /// <typeparam name="TEnum">enum</typeparam>
        /// <typeparam name="TAttribute">想要獲取的Attribute</typeparam>
        /// <typeparam name="TResult">返回結果</typeparam>
        /// <param name="e"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TResult GetAttributeValue<TAttribute,TResult>(
            this Enum e, Func<TAttribute, TResult> func)
            where TAttribute : Attribute
        {
            FieldInfo field = e.GetType().GetField(e.ToString());
            TAttribute attr = Attribute.GetCustomAttribute
                (field, typeof(TAttribute)) as TAttribute;

            return func(attr);
        }
    }
}