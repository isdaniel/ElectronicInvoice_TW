using ElectronicInvoice.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ElectronicInvoice.Core.Infrastructure.Helper
{
    public interface IConfig
    {
        string GovAppId { get; }

        string GovAPIKey { get; }

        string Key { get; }

        string IV { get; }
    }

    public class ConfigHelper : IConfig
    {
        public string IV
        {
            get
            {
                return ConfigurationManager.AppSettings["IsMockAPI"];//setvice.GetCryp("EIVoiceIV");
            }
        }

        public string Key
        {
            get
            {
                return ConfigurationManager.AppSettings["IsMockAPI"];//setvice.GetCryp("EIVoiceKey");
            }
        }

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
                return ConfigurationManager.AppSettings["IsMockAPI"];//setvice.GetCryp("GovAppId");
            }
        }

        public string GovAPIKey
        {
            get
            {
                return ConfigurationManager.AppSettings["IsMockAPI"];//setvice.GetCryp("GovAPIKey");
            }
        }
    }

}