using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Produce.Base
{
    public interface IConfig
    {
        string GovAppId { get; }

        string GovAPIKey { get; }

        string IsMockAPI { get; }
    }
    
    public interface IKeyProvider
    {
        string Key { get;}

        string IV { get; }
    }
}
