using ElectronicInvoice.Dao;
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
        string IV { get; }

        string Key { get; }
    }

    public class ConfigHelper : IConfig
    {
        private EncryptService setvice = new EncryptService();

        public string IV
        {
            get
            {
                return setvice.GetCryp("EIVoiceIV");
            }
        }

        public string Key
        {
            get
            {
                return setvice.GetCryp("EIVoiceKey");
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
                return setvice.GetCryp("GovAppId");
            }
        }

        public string GovAPIKey
        {
            get
            {
                return setvice.GetCryp("GovAPIKey");
            }
        }
    }

    public class EncryptService
    {
        private CrypStoreDao dao = new CrypStoreDao();

        public string GetCryp(string type)
        {
            return dao.GetCrypStore().Where(o => o.ParamterType == type).
                Select(o => o.ParamterContent).FirstOrDefault();
        }
    }
}