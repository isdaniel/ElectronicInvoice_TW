using System;
using System.Threading;
using ElectronicInvoice.Produce.API.Application;
using ElectronicInvoice.Produce.API.Business;
using ElectronicInvoice.Produce.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElectronicInvoiceTests
{
    [TestClass]
    public class ActionMapperTest
    {
        [TestMethod]
        public void Mapper_Test_OK()
        {
            Assert.AreEqual(new DonateVerifyApi(null,null).GetMapperAction, "preserveCodeCheck");
            Assert.AreEqual(new CellphoneVerifyApi(null,null).GetMapperAction, "bcv");
            Assert.AreEqual(new CarrierDetailApi(null,null).GetMapperAction, "carrierInvDetail");
            Assert.AreEqual(new CarrierDonateApi(null,null).GetMapperAction, "carrierInvDnt");
            Assert.AreEqual(new DonatedGroupApi(null,null).GetMapperAction, string.Empty);
        }
    }
}
