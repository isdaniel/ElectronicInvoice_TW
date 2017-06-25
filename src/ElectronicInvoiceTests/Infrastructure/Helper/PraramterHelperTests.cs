using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicInvoice.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Infrastructure.Helper.Tests
{
    [TestClass()]
    public class PraramterHelperTests
    {
        private Dictionary<string, string> dict;
        [TestInitialize] 
        public void Init() {
            dict = new Dictionary<string, string>();
        }
        [TestMethod()]
        public void DictionaryToParamter_fullString_True()
        {
            dict["name"] = "daniel";
            dict["age"] = "1234";

            string expected = "name=daniel&age=1234";

            string result = PraramterHelper.DictionaryToParamter(dict);
            Assert.AreEqual(result,expected);
        }
        [TestMethod()]
        public void DictionaryToParamter_hasNullString_True()
        {
            dict["name"] = "daniel";
            dict["age"] = null;

            string expected = "name=daniel&age=";
            string result = PraramterHelper.DictionaryToParamter(dict);

            Assert.AreEqual(result, expected);
        }
    }
}