using System;

namespace ElectronicInvoice.Produce.Helper
{
    internal class CommonHelper
    {
        /// <summary>
        /// 計算現在的 TimeStamp
        /// </summary>
        internal static long GetTimeStamp()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }
    }
}
