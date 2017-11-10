using AOPLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOPLib.Core;

namespace AOPLib.FilterAttribute
{
    public abstract class AopBaseAttribute : Attribute, IExcuteFilter
    {
        public virtual void MethodExcuted(ExcutedContext result)
        {
        }

        public virtual void MethodExcuting(ExcuteingContext args)
        {
        }
    }
}