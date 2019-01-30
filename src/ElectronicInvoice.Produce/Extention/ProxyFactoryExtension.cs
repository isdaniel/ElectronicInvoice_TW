using AwesomeProxy;
using ElectronicInvoice.Produce.Base;

namespace ElectronicInvoice.Produce
{
    internal static class ProxyFactoryExtension
    {
        internal static ApiBase<T> GetProxyApi<T>(this ApiBase<T> obj,IConfig config)
            where  T:class,new()
        {
            obj.ConfigSetting = config;
            return ProxyFactory.GetProxyInstance(obj);
        }
    }
}
