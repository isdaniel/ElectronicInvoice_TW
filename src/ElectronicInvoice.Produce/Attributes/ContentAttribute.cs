using System;

namespace ElectronicInvoice.Produce.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ContentAttribute : Attribute
    {
        public string Name { get; set; }
    }
}