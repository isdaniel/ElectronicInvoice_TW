using ElectronicInvoice.Models.DBModel;
using ElectronicInvoice.Produce.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ElectronicInvoice.Produce.Infrastructure.Helper
{
    /// <summary>
    /// 吃WebSetting
    /// </summary>
    public class AppsettingConfig : IConfig
    {
        public string IsMockAPI
        {
            get
            {
                return ConfigurationManager.AppSettings["IsMockAPI"];
            }
        }

        public string GovAppId
        {
            get
            {
                return ConfigurationManager.AppSettings["GovAppId"];
            }
        }

        public string GovAPIKey
        {
            get
            {
                return ConfigurationManager.AppSettings["GovAPIKey"];
            }
        }
    }
}