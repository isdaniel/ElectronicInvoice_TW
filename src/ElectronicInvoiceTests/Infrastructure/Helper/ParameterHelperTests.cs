using System.Collections.Generic;
using ElectronicInvoice.Produce.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElectronicInvoiceTests.Infrastructure.Helper
{
    [TestClass()]
    public class ParameterHelperTests
    {
        private Dictionary<string, string> dict;

        [TestInitialize]
        public void Init()
        {
            dict = new Dictionary<string, string>();
        }

        [TestMethod()]
        public void DictionaryToParameter_fullString_True()
        {
            dict["name"] = "daniel";
            dict["age"] = "1234";

            string expected = "name=daniel&age=1234";

            string result = ParameterHelper.DictionaryToParameter(dict);
            Assert.AreEqual(result, expected);
        }

        [TestMethod()]
        public void DictionaryToParameter_hasNullString_True()
        {
            dict["name"] = "daniel";
            dict["age"] = null;

            string expected = "name=daniel&age=";
            string result = ParameterHelper.DictionaryToParameter(dict);

            Assert.AreEqual(result, expected);
        }
    }
}