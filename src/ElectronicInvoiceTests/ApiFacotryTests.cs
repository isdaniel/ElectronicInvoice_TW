using NUnit.Framework;
using ElectronicInvoice.Produce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Factroy;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce.Tests
{
    /// <summary>
    /// 測試api工廠
    /// </summary>
    [TestFixture()]
    public class QryWinningListMockApiTests
    {
        public interface ITester
        {
            void Compare();
        }

        public class Tester<T> : ITester
            where T : class, new()
        {
            /// <summary>
            /// API類型
            /// </summary>
            public Type ApiType { get; set; }

            public void Compare()
            {
                MoblieInvoiceApiFactroy factory = new MoblieInvoiceApiFactroy();
                var model = Activator.CreateInstance(typeof(T)) as T;

                var reuslt = factory.GetInstace(model);

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
        public static IEnumerable<ITester> TestCases()
        {
            yield return new Tester<QryWinningListModel> { ApiType = typeof(QryWinningListApi) };
            yield return new Tester<qryInvDetailModel> { ApiType = typeof(qryInvDetailApi) };
            yield return new Tester<CarrierTilteModel> { ApiType = typeof(CarrierTilteApi) };
            yield return new Tester<CarrierDetailModel> { ApiType = typeof(CarrierDetailApi) };
        }

        [Test]
        [TestCaseSource("TestCases")]
        public void facotryProduce_Test_True(ITester tester)
        {
            tester.Compare();
        }
    }
}