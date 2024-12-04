using System.Linq;
using System.Reflection;
using ElectronicInvoice.Produce;
using ElectronicInvoice.Produce.Attributes;
using NUnit.Framework;

namespace ElectronicInvoiceTests
{
    [TestFixture()]
    public class AssemblyProvierTests
    {
        [Test()]
        public void RegisterAssembly_Contain_NewOne()
        {
            ApiTypeProvider.Instance.RegisterAssembly(Assembly.GetExecutingAssembly());

            Assert.IsTrue(ApiTypeProvider.Instance.AssemblyList.Any(x=> x == Assembly.GetExecutingAssembly()));
            Assert.IsTrue(ApiTypeProvider.Instance.AssemblyList.Any(x => x == Assembly.Load("ElectronicInvoice.Produce")));
        }

        [Test()]
        public void RegisterAssembly_Contain()
        {
            ApiTypeProvider.Instance.RegisterAssembly(Assembly.GetExecutingAssembly());

            var act = ApiTypeProvider.Instance.GetTypeFromAssembly<ApiTypeAttribute>().FirstOrDefault(x => x == typeof(TestModel));

            Assert.AreEqual(typeof(TestModel), act);
        }
    }
}