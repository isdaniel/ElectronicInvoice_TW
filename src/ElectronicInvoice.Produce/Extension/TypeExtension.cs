using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Extension
{
    internal static class TypeExtension
    {
        public static string GetCardName(this CardType type)
        {
            return type.GetAttributeValue<ContentAttribute, string>(x => x.Name);
        }
    }
}
