using AOPLib.FilterAttribute;
using AOPLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOPLib
{
    public class FilterInfo
    {
        private List<IExcuteFilter> _excuteFilters = new List<IExcuteFilter>();
        private List<IExceptionFilter> _exceptionFilters = new List<IExceptionFilter>();

        public FilterInfo(MarshalByRefObject target, MethodInfo method)
        {
            var classAttr = target.GetType().GetCustomAttributes(typeof(Attribute), true);
            var methodAttr = Attribute.GetCustomAttributes(method, typeof(Attribute), true);
            var unionAttr = classAttr.Union(methodAttr);
            _excuteFilters.AddRange(unionAttr.OfType<IExcuteFilter>());
            _exceptionFilters.AddRange(unionAttr.OfType<IExceptionFilter>());
        }

        public IList<IExcuteFilter> ExcuteFilters
        {
            get
            {
                return _excuteFilters;
            }
        }

        public IList<IExceptionFilter> ExceptionFilters
        {
            get
            {
                return _exceptionFilters;
            }
        }
    }
}