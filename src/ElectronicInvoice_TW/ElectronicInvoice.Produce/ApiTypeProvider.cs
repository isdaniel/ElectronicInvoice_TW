﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ElectronicInvoice.Produce
{
    public class ApiTypeProvider
    {
        private object _sync = new object();

        private readonly static ApiTypeProvider _instance = new ApiTypeProvider();
        public static ApiTypeProvider Instance => _instance;
        
        private ApiTypeProvider()
        {
            AssemblyList = new List<Assembly>()
            {
                Assembly.Load("ElectronicInvoice.Produce")
            };
        }

        public List<Assembly> AssemblyList { get; }

        public void RegisterAssembly(Assembly assembly)
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
