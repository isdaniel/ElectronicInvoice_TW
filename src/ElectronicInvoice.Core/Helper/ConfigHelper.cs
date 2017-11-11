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
                return setvice.GetCryp("EIVoiceIV").FirstOrDefault();
            }
        }

        public string Key
        {
            get
            {
                return setvice.GetCryp("EIVoiceKey").FirstOrDefault();
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
                return setvice.GetCryp("GovAppId").FirstOrDefault();
            }
        }

        public string GovAPIKey
        {
            get
            {
                return setvice.GetCryp("GovAPIKey").FirstOrDefault();
            }
        }
    }

    public class EncryptService
    {
        private CrypStoreDao dao = new CrypStoreDao();

        public IEnumerable<string> GetCryp(string type)
        {
            return dao.GetCrypStore().Where(o => o.ParamterType == type).Select(o => o.ParamterContent);
        }
    }
}