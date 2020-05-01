using AwesomeProxy;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce.Extension
{
    internal static class ProxyFactoryExtension
    {
        internal static ApiBase<T> GetProxyApi<T>(this ApiBase<T> obj)
            where T:class,new()
        {
            return ProxyFactory.GetProxyInstance(obj);
        }
    }
}
