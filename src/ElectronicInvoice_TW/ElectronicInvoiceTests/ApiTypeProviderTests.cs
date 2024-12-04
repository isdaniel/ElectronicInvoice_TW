using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ElectronicInvoice.Produce;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Mapping;
using NUnit.Framework;

namespace ElectronicInvoiceTests
{
    [TestFixture]
    public class ApiTypeProviderTests
    {
        [Test]
        public void Instance_ShouldReturnSameInstance()
        {
            // Arrange & Act
            var instance1 = ApiTypeProvider.Instance;
            var instance2 = ApiTypeProvider.Instance;

            // Assert
            Assert.AreSame(instance1, instance2);
        }

        [Test]
        public void AssemblyList_ShouldContainDefaultAssembly()
        {
            // Arrange
            var provider = ApiTypeProvider.Instance;

            // Act
            var assemblies = provider.AssemblyList;

            // Assert
            Assert.IsNotEmpty(assemblies);
            Assert.IsTrue(assemblies.Any(a => a.GetName().Name == "ElectronicInvoice.Produce"));
        }

        [Test]
        public void RegisterAssembly_ShouldAddAssemblyToList()
        {
            // Arrange
            var provider = ApiTypeProvider.Instance;
            var assemblyName = "System.Linq";
            var assembly = Assembly.Load(assemblyName);

            // Act
            provider.RegisterAssembly(assembly);

            // Assert
            Assert.IsTrue(provider.AssemblyList.Any(a => a.GetName().Name == assemblyName));
        }

        [Test]
        public void GetTypeFromAssembly_ShouldReturnTypesWithSpecifiedAttribute()
        {
            var provider = ApiTypeProvider.Instance;
            var testAssembly = Assembly.GetExecutingAssembly();
            provider.RegisterAssembly(testAssembly);
            var result = provider.GetTypeFromAssembly<ApiTypeAttribute>();
            Assert.IsNotEmpty(result);
            Assert.IsTrue(result.Any(type => type == typeof(QryCarrierAggModel)));
        }
    }

}
