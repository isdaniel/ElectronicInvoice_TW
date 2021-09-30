using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Helper;

namespace ElectronicInvoice.Produce.Infrastructure
{
    public class CommonBaseModel
    {
        public string TimeStamp => (CommonHelper.GetTimeStamp() + 15).ToString();

        public string TimeStampMAX => (CommonHelper.GetTimeStamp() + 10000).ToString();

        public string UUID => "9774d56d682e549c";

        public string Serial => DateTime.Now.ToString("MMddssmmss");

        public string Version { get; set; } = "0.3";
    }
}
