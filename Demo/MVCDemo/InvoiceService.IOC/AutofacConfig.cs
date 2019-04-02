using Autofac;
using ElectronicInvoice.Core.Extension;
using ElectronicInvoice.IOC.Profiles;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Factory;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Service;

namespace ElectronicInvoice.IOC
{
    /// <summary>
    /// DI設定檔
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 註冊DI注入物件資料
        /// </summary>
        public static ContainerBuilder Register()
        {
            // 容器建立者
            ContainerBuilder builder = new ContainerBuilder();

            builder.AddAutoMapperProfileByAssembly(typeof(InvoiceProfile).Assembly);
            
            builder.RegisterType<AppsettingConfig>().As<IConfig>().InstancePerRequest();
            builder.RegisterGeneric(typeof(ApiBase<>)).PropertiesAutowired();
            builder.RegisterType<InvoiceApiFactory>().InstancePerRequest();
            builder.RegisterType<InvoiceService>().As<IInvoiceService>().InstancePerRequest();

            // 建立容器
            return builder;
        }
    }
}