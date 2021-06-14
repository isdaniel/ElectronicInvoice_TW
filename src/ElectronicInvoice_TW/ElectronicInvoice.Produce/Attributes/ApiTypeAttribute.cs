﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicInvoice.Produce.Attributes {

    [AttributeUsage(AttributeTargets.Class)]
    public class ApiTypeAttribute : Attribute
    {
        /// <summary>
        /// 呼叫大平台API型別
        /// </summary>
        public Type ApiType { get; set; }
    }
}