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
        public string TimeStamp
        {
            get
            {
                return (CommonHelper.GetTimeStamp() + 15).ToString();
            }
        }

        public string TimeStampMAX
        {
            get
            {
                return (CommonHelper.GetTimeStamp() + 10000).ToString();
            }
        }

        public string UUID
        {
            get
            {
                return "9774d56d682e549c";
            }
        }
    }
}
