using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicInvoice.Infrastructure.Common
{
    public class ApiTypeAttribute : Attribute
    {
        public Type ApiType { get; private set; }

        public ApiTypeAttribute(Type type)
        {
            ApiType = type;
        }
    }
}