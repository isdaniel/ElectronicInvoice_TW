using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicInvoice.Infrastructure.AOP;
using System;
using Moq;
using ElectronicInvoice.Service;

namespace ElectronicInvoice.Infrastructure.AOP.Tests
{
    public class TestModel
    {
        public int testData { get; set; }
    }

    [TestClass()]
    public class ProxyFactoryTests
    {
        private ApiBase<TestModel> moqApi = null;
        private TestModel model = new TestModel();

        [TestInitialize]
        public void Init()
        {
            var moqObj = new Mock<ApiBase<TestModel>>();
            moqObj.Setup(api => api.ExcuteApi(model)).Returns("{OK}");
            moqApi = moqObj.Object;
        }

        [TestMethod]
        public void LogProxy_ApiBase_True()
        {
            var expect = "{OK}";
            var proxy = ProxyFactory.CreateProxyInstance<IApiRunner>(moqApi);
            var result = proxy.ExcuteApi(model);
            Assert.AreEqual(result, expect);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "被代理對象需繼承於MarshalByRefObject")]
        public void LogProxy_WithOutMarshalByRefObject_ThrowExpcetion()
        {
            TestModel m = new TestModel();
            var proxy = ProxyFactory.CreateProxyInstance<IApiRunner>(m);
            proxy.ExcuteApi(m);
        }
    }
}