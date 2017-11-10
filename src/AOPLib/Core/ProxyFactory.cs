using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPLib.Core
{
    public class ProxyFactory
    {
        /// <summary>
        /// 取得代理實體
        /// </summary>
        /// <param name="para">建構子參數</param>
        public static TOjbect GetProxyInstance<TOjbect>(object[] para = null)
            where TOjbect : MarshalByRefObject
        {
            TOjbect obj = Activator.CreateInstance(typeof(TOjbect), para) as TOjbect;
            return GetProxyInstance(obj);
        }

        /// <summary>
        /// 取得代理實體
        /// </summary>
        /// <typeparam name="TOjbect">代理類型別</typeparam>
        /// <param name="subjectType">被代理類型別</param>
        /// <param name="para">被代理類建構子參數</param>
        /// <returns></returns>
        public static TOjbect GetProxyInstance<TOjbect>(Type subjectType, object[] para = null)
            where TOjbect : MarshalByRefObject
        {
            TOjbect obj = Activator.CreateInstance(subjectType, para) as TOjbect;

            if (obj == null)
            {
                throw new ArgumentException(string.Format("傳入 subjectType 需繼承於{0}",
                    typeof(TOjbect).Name));
            }

            return GetProxyInstance(obj);
        }

        /// <summary>
        /// 取得代理實體
        /// </summary>
        /// <typeparam name="TOjbect">代理類型別</typeparam>
        /// <param name="realSubjcet">被代理類別實體</param>
        /// <returns></returns>
        public static TOjbect GetProxyInstance<TOjbect>(TOjbect realSubjcet)
             where TOjbect : MarshalByRefObject
        {
            var _proxy = new DynamicProxy<TOjbect>(realSubjcet);
            return _proxy.GetTransparentProxy() as TOjbect;
        }

    }
}