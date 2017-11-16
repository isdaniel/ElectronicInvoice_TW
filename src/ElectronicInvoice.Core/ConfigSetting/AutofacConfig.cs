using Autofac;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Factroy;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Infrastructure.Helper;
using ElectronicInvoice.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicInvoice.Core.ConfigSetting
{
    /// <summary>
    /// DI設定檔
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 註冊DI注入物件資料
        /// </summary>
        public static IContainer Register()
        {
            // 容器建立者
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<AppsettingConfig>().As<IConfig>();
            builder.RegisterGeneric(typeof(ApiBase<>)).PropertiesAutowired();
            builder.RegisterType<InvoiceApiFactroy>();

            // 建立容器
            return builder.Build();
        }
    }
}