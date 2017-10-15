using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Services;
using System.Web;

namespace ElectronicInvoice.Infrastructure.AOP
{
    /// <summary>
    /// 動態代理類別
    /// </summary>
    internal class AOPRealProxy : RealProxy, IProxyDI
    {
        /// <summary>
        /// 被代理對象
        /// </summary>
        private MarshalByRefObject _target = null;

        /// <summary>
        /// 攔截器
        /// </summary>
        private IInterception _interception = null;

        /// <summary>
        /// 動態代理類的建構子
        /// </summary>
        /// <param name="instace">需要被代理的物件(需繼承於MarshalByRefObject)</param>
        public AOPRealProxy(object instace)
            : base(instace.GetType())
        {
            _target = (MarshalByRefObject)instace;
            _interception = new LogInterception();
        }

        /// <summary>
        /// 實現Invoke方法
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public override IMessage Invoke(IMessage msg)
        {
            IMethodReturnMessage methodReturnMessage = null;
            IMethodCallMessage methodCallMessage = msg as IMethodCallMessage;
            MethodInfo method = methodCallMessage.MethodBase as MethodInfo;
            if (methodCallMessage != null)
            {
                IConstructionCallMessage constructionCallMessage = methodCallMessage as IConstructionCallMessage;
                if (constructionCallMessage != null)
                {
                    RealProxy defaultProxy = RemotingServices.GetRealProxy(_target);
                    defaultProxy.InitializeServerObject(constructionCallMessage);
                    methodReturnMessage = EnterpriseServicesHelper.CreateConstructionReturnMessage(constructionCallMessage, (MarshalByRefObject)GetTransparentProxy());
                }
                else
                {
                    _interception.PreInvoke(methodCallMessage);
                    try
                    {
                        var result = method.Invoke(_target, methodCallMessage.Args);
                        methodReturnMessage = new ReturnMessage(
                            result,
                            null,
                            0, methodCallMessage.LogicalCallContext,
                            methodCallMessage);
                    }
                    catch (Exception ex)
                    {
                        methodReturnMessage = new ReturnMessage(ex, methodCallMessage);
                        _interception.ExceptionHandle(methodReturnMessage);
                    }

                    _interception.PostInvoke(methodReturnMessage);
                }
            }
            return methodReturnMessage;
        }

        #region IProxyDI

        /// <summary>
        /// 設置此次代理的攔截器物件
        /// </summary>
        /// <param name="interception">攔截器</param>
        public void InterceptionDI(IInterception interception)
        {
            _interception = interception;
        }

        #endregion IProxyDI
    }
}