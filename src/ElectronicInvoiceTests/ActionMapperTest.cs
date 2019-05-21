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
            Assert.AreEqual(new DonateVerifyApi().GetMapperAction, "preserveCodeCheck");
            Assert.AreEqual(new CellphoneVerifyApi().GetMapperAction, "bcv");
            Assert.AreEqual(new CarrierDetailApi().GetMapperAction, "carrierInvDetail");
            Assert.AreEqual(new CarrierDonateApi().GetMapperAction, "carrierInvDnt");
            Assert.AreEqual(new DonatedGroupApi().GetMapperAction, string.Empty);
        }
    }
}
