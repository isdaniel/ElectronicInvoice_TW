using ElectronicInvoice.Produce.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Produce.Infrastructure
{
    public class DbKeyProvider : IKeyProvider
    {
        public string IV => "959DC314";

        public string Key => "AB3E4C7B";
    }
}
