using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using System.Threading.Tasks;

namespace ElectronicInvoiceTests
{
    //model class should be public
    [ApiType(ApiType = typeof(MockApi))]
    public class TestModel { }
    internal class InvalidModel { }
    internal class MockApi : ApiBase<TestModel>
    {
        internal MockApi(IConfig config, ISysLog log) : base(config, log)
        {
        }

        public override string ExecuteApi(TestModel model) => "Test Result";

        protected override string SetParameter(TestModel model)
        {
            return "mock_parameter";
        }

        public override Task<string> ExecuteApiAsync(TestModel model)
        {
            return Task.FromResult("Async Result");
        }
    }
}
