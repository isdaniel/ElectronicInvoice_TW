using System;
using System.Collections.Generic;
using ElectronicInvoice.Produce;
using ElectronicInvoice.Produce.API;
using ElectronicInvoice.Produce.API.Application;
using ElectronicInvoice.Produce.Factory;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Mapping;
using Moq;
using NUnit.Framework;

namespace ElectronicInvoiceTests
{
    /// <summary>
    /// 測試api工廠
    /// </summary>
    [TestFixture()]
    public class ApiFactoryTests
    {
        private static IConfig _config;

        [SetUp]
        public void Init()
        {
            Mock<IConfig> moqConfig = new Mock<IConfig>();
            moqConfig.Setup(o => o.GovAPIKey).Returns("0");
            moqConfig.Setup(o => o.IsMockAPI).Returns("0");
            moqConfig.Setup(o => o.GovAppId).Returns("0");
            _config = moqConfig.Object;
        }
        public interface ITester
        {
            void Compare();
        }

        private class Tester<T> : ITester
            where T : class, new()
        {
            /// <summary>
            /// API類型
            /// </summary>
            public Type ApiType { get; set; }

            public void Compare()
            {
                InvoiceApiFactory factory = new InvoiceApiFactory(_config);

                var model = Activator.CreateInstance(typeof(T)) as T;

                var reuslt = factory.GetProxyInstace(model);

                Assert.AreEqual(ApiType, reuslt.GetType());
            }
        }

        /// <summary>
        /// TestCaseSource
        /// 1.是方法,屬性,自段
        /// 2.是一個物件或是靜態的
        /// 3.需繼承IEnumerable的集合
        /// 4.返回值須和測試的傳入參數對應上
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<ITester> TestCases()
        {
            yield return new Tester<QryWinningListModel> { ApiType = typeof(QryWinningListApi) };
            yield return new Tester<CarrierTitleModel> { ApiType = typeof(CarrierTitleApi) };
            yield return new Tester<CarrierDetailModel> { ApiType = typeof(CarrierDetailApi) };
            yield return new Tester<QryCarrierAggModel> { ApiType = typeof(QryCarrierAggApi) };
            yield return new Tester<DonateQueryModel> { ApiType = typeof(DonateQueryApi) };
            yield return new Tester<InvoiceDetailModel> { ApiType = typeof(InvoiceDetailApi) };
            yield return new Tester<InvoiceTitleModel> { ApiType = typeof(InvoiceTitleApi) };
        }

        [Test]
        [TestCaseSource("TestCases")]
        public void FactoryProduce_Test_True(ITester tester)
        {
            tester.Compare();
        }
    }
}