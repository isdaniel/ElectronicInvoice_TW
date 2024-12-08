using System;
using System.Collections.Generic;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Helper;
using NUnit.Framework;

namespace ElectronicInvoiceTests.Infrastructure.Helper
{
    [TestFixture]
    public class JsonConfigTest
    {
        [Test]
        public void Invalid_JsonFile_Null()
        {
            string JsonData = null;
            Assert.Throws<ArgumentException>(() => { new JsonConfig(JsonData); }, "parameter JsonData can't be Null or empty string");
        }

        [Test]
        public void Invalid_JsonFile_EmptyString()
        {
            string JsonData = string.Empty;
            Assert.Throws<ArgumentException>(() => { new JsonConfig(JsonData); }, "parameter JsonData can't be Null or empty string");
        }

        [Test]
        public void JsonFileTest()
        {
            string GovAppId = "GovAppId123";
            string GovAPIKey = "GovAPIKey123";
            string IsMockAPI = "IsMockAPI123";

            Dictionary<string, string> apiUrlTable = new Dictionary<string, string>()
            {
                {"ApiURL1","ApiURL1"},
                {"ApiURL2","ApiURL2"},
                {"ApiURL3","ApiURL3"}
            };

            string JsonData = @"{
	""GovAppId"":""GovAppId123"",
	""GovAPIKey"":""GovAPIKey123"",
	""IsMockAPI"":""IsMockAPI123"",
	""ApiURLTable"":{
		""ApiURL1"":""ApiURL1"",
		""ApiURL2"":""ApiURL2"",
		""ApiURL3"":""ApiURL3""
	}
}";
            JsonConfig config = new JsonConfig(JsonData);
            var actApiUrlTable = config.GetApiURLTable();

            Assert.AreEqual(config.GovAppId, GovAppId);
            Assert.AreEqual(config.GovAPIKey, GovAPIKey);
            Assert.AreEqual(config.IsMockAPI, IsMockAPI);
            Assert.AreEqual(actApiUrlTable["ApiURL1"], apiUrlTable["ApiURL1"]);
            Assert.AreEqual(actApiUrlTable["ApiURL2"], apiUrlTable["ApiURL2"]);
            Assert.AreEqual(actApiUrlTable["ApiURL3"], apiUrlTable["ApiURL3"]);
        }
    }
}
