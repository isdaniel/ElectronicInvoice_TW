using ElectronicInvoice.Produce.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Produce.Infrastructure
{
    public class DBKeyProvider : IKeyProvider
    {
        public string IV
        {
            get
            {
                return "959DC314";
            }
        }

        public string Key
        {
            get
            {
                return "AB3E4C7B";
            }
        }

    }
}
