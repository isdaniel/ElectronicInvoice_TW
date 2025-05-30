﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Produce.Infrastructure
{
    internal class InvoiceContainer
    {
        private readonly static InvoiceContainer _instance = new InvoiceContainer();

        internal static InvoiceContainer Instance => _instance;

        private InvoiceContainer()
        {
            Container = new Dictionary<Type, object>();
        }

        internal Dictionary<Type, object> Container { get; }

        internal T GetObject<T>() 
            where T : class
        {
            object obj;

            if (Container.TryGetValue(typeof(T),out obj))
            {
                return obj as T;
            }

            return null;
        }

        internal bool TryToAdd<T>(T obj) 
            where T : class
        {
            if (!Container.ContainsKey(typeof(T)))
            {
                Container.Add(typeof(T),obj);
                return true;
            }

            return false;
        }
    }
}
