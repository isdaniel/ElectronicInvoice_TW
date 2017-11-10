using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ElectronicInvoice.Infrastructure.Helper
{
    public interface IConfig
    {
        string IV { get; }

        string Key { get; }

        string InvoiceApiAssemebly { get; }
    }

    public class ConfigHelper : IConfig
    {
        public string IV
        {
            get
            {
                return ConfigurationManager.AppSettings["IV"];
            }
        }

        public string Key
        {
            get
            {
                return ConfigurationManager.AppSettings["Key"];
            }
        }

        public string InvoiceApiAssemebly
        {
            get
            {
                return ConfigurationManager.AppSettings["InvoiceApiAssemebly"];
            }
        }

        public string IsMockAPI
        {
            get
            {
                return ConfigurationManager.AppSettings["IsMockAPI"];
            }
        }
    }
}