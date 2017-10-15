using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicInvoice.Infrastructure.Common
{
    public class ApiTypeAttribute : Attribute
    {
        /// <summary>
        /// 呼叫大平台API型別
        /// </summary>
        public Type ApiType { get; set; }

        private Type _MockApiType;

        /// <summary>
        /// 模擬API型別
        /// </summary>
        public Type MockApiType
        {
            get
            {
                return _MockApiType ?? ApiType;
            }
            set
            {
                _MockApiType = value;
            }
        }
    }
}