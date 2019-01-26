using NUnit.Framework;
using ElectronicInvoice.Produce;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Attributes;

namespace ElectronicInvoice.Produce.Tests
{
    public  class MyApiClass{
    }

    [ApiType(ApiType = typeof(MyApiClass))]
    public class APIModel
    {
    }

    [TestFixture()]
    public class AssemblyProvierTests
    {
        [Test()]
        public void RegistertAssembly_Contain_NewOne()
        {
            AssemblyProvier.Instance.RegistertAssembly(Assembly.GetExecutingAssembly());

            Assert.IsTrue(AssemblyProvier.Instance.AssemblyList.Any(x=> x == Assembly.GetExecutingAssembly()));
            Assert.IsTrue(AssemblyProvier.Instance.AssemblyList.Any(x => x == Assembly.Load("ElectronicInvoice.Produce")));
        }

        [Test()]
        public void RegistertAssembly_Contain_()
        {
            AssemblyProvier.Instance.RegistertAssembly(Assembly.GetExecutingAssembly());

            var act = AssemblyProvier.Instance.GetTypeFromAssembly<ApiTypeAttribute>()
                .FirstOrDefault(x => x == typeof(APIModel));

            Assert.AreEqual(act,typeof(APIModel));
        }
    }
}