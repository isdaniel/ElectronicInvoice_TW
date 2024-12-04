using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ElectronicInvoice.Produce
{
    public class ApiTypeProvider
    {
        private static readonly Lazy<ApiTypeProvider> _instance = new Lazy<ApiTypeProvider>(() => new ApiTypeProvider());

        public static ApiTypeProvider Instance => _instance.Value;

        private readonly HashSet<Assembly> _assemblyList;

        private ApiTypeProvider()
        {
            _assemblyList = new HashSet<Assembly>
            {
                Assembly.Load("ElectronicInvoice.Produce")
            };
        }

        public IList<Assembly> AssemblyList
        {
            get {
                lock (_assemblyList)
                {
                    return _assemblyList.ToList();
                }
            }
        }

        // Ensure thread safety when modifying the list
        public virtual void RegisterAssembly(Assembly assembly)
        {
            lock (_assemblyList)
            {
                _assemblyList.Add(assembly);
            }
        }

        public virtual IEnumerable<Type> GetTypeFromAssembly<T>() where T : Attribute
        {
            return AssemblyList
               .SelectMany(a => a.GetExportedTypes())
               .Where(t => t.GetCustomAttribute<T>() != null);
        }
    }
}
