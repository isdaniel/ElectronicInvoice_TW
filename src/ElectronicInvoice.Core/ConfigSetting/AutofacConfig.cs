using Autofac;
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

            // 註冊Controllers
            // builder.RegisterControllers(System.Reflection.Assembly.GetExecutingAssembly());

            //// 註冊DbContextFactory
            //string connectionString =
            //    ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //builder.RegisterType<DbContextFactory>()
            //    .WithParameter("connectionString", connectionString)
            //    .As<IDbContextFactory>()
            //    .InstancePerHttpRequest();

            // 建立容器
            return builder.Build();
        }
    }
}