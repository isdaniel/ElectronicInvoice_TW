using AOPLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPLib.Interface
{
    public interface IExcuteFilter
    {
        void MethodExcuted(ExcutedContext result);

        void MethodExcuting(ExcuteingContext args);
    }

    public interface IExceptionFilter
    {
        void MethodException(Exception ex);
    }
}