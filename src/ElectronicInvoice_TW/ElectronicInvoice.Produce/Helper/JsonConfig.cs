using System.Collections.Generic;
using ElectronicInvoice.Produce.Facade;

namespace ElectronicInvoice.Produce.Helper
{
    public class JsonConfig : IConfig
    {
        private ConfigModel _configModel;

        public JsonConfig(string JsonData)
        {
            _configModel = JsonConvertFacde.DeserializeObject<ConfigModel>(JsonData);
        }

        public string GovAppId => _configModel.GovAppId;
        public string GovAPIKey => _configModel.GovAPIKey;
        public string IsMockAPI => _configModel.IsMockAPI;

        public Dictionary<string, string> GetApiURLTable()
        {
            return _configModel.ApiURLTable;
        }
    }
}
