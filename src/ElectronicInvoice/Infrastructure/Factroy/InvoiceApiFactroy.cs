using ElectronicInvoice.Service;
using System;
using System.Configuration;
using System.Reflection;
using System.Linq;
using ElectronicInvoice.Infrastructure.Common;

namespace ElectronicInvoice.Infrastructure.Factroy
{
    public class MoblieInvoiceApiFactroy
    {
        private static string _assemblyname = "";

        /// <summary>
        /// InvoiceApiAssemebly名稱
        /// </summary>
        public static string AssemblyName
        {
            get
            {
                string _assemblyname = ConfigurationManager.AppSettings["InvoiceApiAssemebly"];

                if (string.IsNullOrEmpty(_assemblyname))
                {
                    _assemblyname = "ElectronicInvoice.Service";
                }

                return _assemblyname;
            }
        }

        /// <summary>
        /// 提供api的工廠
        /// Model和Api命名要相關
        /// 例如:testModel 對 testApi
        /// </summary>
        /// <param name="model">Model參數</param>
        /// <returns></returns>
        public static IApiRunner GetInstace(object model)
        {
            if (model == null) throw new ArgumentNullException("不能傳空的參數");

            string modelName = model.GetType().Name;
            return (IApiRunner)Activator.CreateInstance
                (GetInstanceType(model), null);
            //modelName = modelName.Replace("Model", "Api")
            //                     .Replace("DTO", "Api");
            //return Assembly.GetAssembly
            //    (typeof(MoblieInvoiceApiFactroy)).CreateInstance(AssemblyName + "." + modelName);
        }

        /// <summary>
        ///
        /// </summary>
        public static Type GetInstanceType(object model)
        {
            var modelType = model.GetType();
            var attr = modelType.GetCustomAttribute(typeof(ApiTypeAttribute)) as ApiTypeAttribute;
            if (attr != null)
            {
                return attr.ApiType;
            }
            throw new Exception("Model尚未賦予ApiTypeAttribute");
        }
    }
}