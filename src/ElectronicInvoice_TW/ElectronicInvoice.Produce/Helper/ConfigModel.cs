using System.Collections.Generic;

namespace ElectronicInvoice.Produce.Helper
{
    internal class ConfigModel
    {
        public string GovAppId { get; set; }
        public string GovAPIKey { get; set; }
        public string IsMockAPI { get; set; }
        public Dictionary<string, string> ApiURLTable { get; set; }
    }
}
