﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ElectronicInvoice.Produce.Base;

namespace ElectronicInvoice.Produce.Helper
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

        public Dictionary<string, string> GetApiURLTable()
        {
            return ConfigurationManager.AppSettings
                            .AllKeys
                            .ToDictionary(x => x, y => ConfigurationManager.AppSettings[y]);
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