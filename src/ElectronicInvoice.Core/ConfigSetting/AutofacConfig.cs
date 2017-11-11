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
        public static void Register()
        {
            // 容器建立者
            //ContainerBuilder builder = new ContainerBuilder();

            // 註冊Controllers
            // builder.RegisterControllers(System.Reflection.Assembly.GetExecutingAssembly());

            //// 註冊DbContextFactory
            //string connectionString =
            //    ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //builder.RegisterType<DbContextFactory>()
            //    .WithParameter("connectionString", connectionString)
            //    .As<IDbContextFactory>()
            //    .InstancePerHttpRequest();

            //// 註冊 Repository UnitOfWork
            //builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>));
            //builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork));

            //// 註冊Services
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //       .Where(t => t.Name.EndsWith("Services"))
            //       .AsImplementedInterfaces();

            // 建立容器
            //IContainer container = builder.Build();

            //AutofacDependencyResolver resolver = new AutofacDependencyResolver(container);

            //DependencyResolver.SetResolver(resolver);
        }
    }
}