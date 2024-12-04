using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce;
using Moq;
using NUnit.Framework;

namespace ElectronicInvoiceTests
{
    [TestFixture]
    public class InvoiceApiContextTests
    {
        private Mock<IConfig> _mockConfig;
        private Mock<ISysLog> _mockLog;
        private Mock<ApiBase<TestModel>> _mockApiBase;

        [SetUp]
        public void SetUp()
        {
            _mockConfig = new Mock<IConfig>();
            _mockLog = new Mock<ISysLog>();
            _mockApiBase = new Mock<ApiBase<TestModel>>();

            ApiTypeProvider.Instance.RegisterAssembly(Assembly.GetExecutingAssembly());
        }

        [Test]
        public void Constructor_WithConfigAndLog_ShouldInitializeCorrectly()
        {
            // Act
            var context = new InvoiceApiContext(_mockConfig.Object, _mockLog.Object);

            // Assert
            Assert.IsNotNull(context);
        }

        [Test]
        public void ExecuteApi_WithValidModel_ShouldReturnExpectedResult()
        {
            // Arrange
            var context = new InvoiceApiContext(_mockConfig.Object, _mockLog.Object);
            var model = new TestModel();
            var expectedResult = "Test Result";

            // Act
            var result = context.ExecuteApi(model);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ExecuteApi_WithInvalidModel_ShouldThrowNotSupportedException()
        {
            // Arrange
            var context = new InvoiceApiContext(_mockConfig.Object, _mockLog.Object);

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => context.ExecuteApi(new InvalidModel()));
        }

        [Test]
        public async Task ExecuteApiAsync_WithValidModel_ShouldReturnExpectedResult()
        {
            // Arrange
            var context = new InvoiceApiContext(_mockConfig.Object, _mockLog.Object);
            var model = new TestModel();
            var expectedResult = "Async Result";

            // Act
            var result = await context.ExecuteApiAsync(model);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }

}
