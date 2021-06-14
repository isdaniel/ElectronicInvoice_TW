﻿using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Helper;
using Moq;
using NUnit.Framework;

namespace ElectronicInvoiceTests.Helper
{
    [TestFixture()]
    public class DesCrypHelperTests
    {
        IKeyProvider KeyProvider;

        [SetUp]
        public void Init()
        {
            Mock<IKeyProvider> moqKey = new Mock<IKeyProvider>();

            moqKey.Setup(o => o.IV).Returns("88888888");
            moqKey.Setup(o => o.Key).Returns("77777777");

            KeyProvider = moqKey.Object;
        }

        [TestCase("!@#)_sdJP你好EWHIEHO")]
        [TestCase("!@*(!@*)!*@()f fjfjop10-")]
        [TestCase("嘻嘻哈哈")]
        public void 一般字串各種符號__字串加解密Test__成功(string input)
        {
            string original = input;
            DesCrypHelper DESTool = new DesCrypHelper(KeyProvider);
            string encryptStr = DESTool.EncryptData(original);
            string result = DESTool.DecryptData(encryptStr);
            Assert.AreEqual(result, original);
        }

        [TestCase(new byte[] { 111,55,1,11,18})]
        [TestCase(new byte[] { 4, 55, 1, 11, 18 })]
        public void 一般字串各種符號__byte加解密Test__成功(byte[] input)
        {
            byte[] original = input;
            DesCrypHelper desTool = new DesCrypHelper(KeyProvider);
            byte[] encryptStr = desTool.EncryptData(original);
            byte[] result = desTool.DecryptData(encryptStr);
            Assert.AreEqual(result, original);
        }
    }
}