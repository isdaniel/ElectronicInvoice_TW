using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Produce
{
    public class AssemblyProvier
    {
        private static AssemblyProvier _instance;
        public static AssemblyProvier Instance => _instance ?? (_instance = new AssemblyProvier());

        private AssemblyProvier()
        {
            AssemblyList = new List<Assembly>()
            {
                Assembly.Load("ElectronicInvoice.Produce")
            };
        }

        public List<Assembly> AssemblyList { get; }

        public void RegistertAssembly(Assembly assembly)
        {
            AssemblyList.Add(assembly);
        }

        internal IEnumerable<Type> GetTypeFromAssembly<T>() where T : Attribute
        {
            return AssemblyList
                .SelectMany(x => x.ExportedTypes, (a, b) => b)
                .Where(x => x.GetCustomAttribute<T>() != null);
        }
    }
}
