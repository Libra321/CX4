/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/16 17:44:41
 ****** 功能描述    ：InterceptorBase
 *******************************************************************************/

using Castle.DynamicProxy;

namespace CX4.Infrastructure.Service.AOP
{
    /// <summary>
    /// 拦截器基类
    /// </summary>
    public abstract class InterceptorBase : IInterceptor
    {
        /// <summary>
        /// 拦截前操作
        /// </summary>
        protected abstract void InterceptBefore(IInvocation invocation);

        /// <summary>
        /// 拦截后操作
        /// </summary>
        protected abstract void InterceptAfter(IInvocation invocation);

        /// <summary>
        ///拦截方法
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            InterceptBefore(invocation);
            invocation.Proceed();
            InterceptAfter(invocation);
        }
    }
}
