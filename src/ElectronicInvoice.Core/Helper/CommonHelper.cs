using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Core.Infrastructure.Helper
{
    public class CommonHelper
    {  
        /// <summary>
        /// 計算現在的 TimeStamp
        /// </summary>
        public static long GetTimeStamp()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }
    }
}
