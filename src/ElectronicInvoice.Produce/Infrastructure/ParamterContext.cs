using ElectronicInvoice.Produce.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectronicInvoice.Produce.Helper;

namespace ElectronicInvoice.Produce.Infrastructure
{
    public partial class ParamterContext
    {
        private IConfig _config { get; set; }

        public ParamterContext(IConfig config)
        {
            _config = config ?? new AppsettingConfig();
        }

        public string GovAPIKey
        {
            get
            {
                return _config.GovAPIKey;
            }
        }

        public string GovAppId
        {
            get
            {
                return _config.GovAppId;
            }
        }
    }

    public enum InvoiceType
    {
        BarCode,
        QRCode
    }
}