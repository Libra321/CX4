/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/16 17:46:54
 ****** 功能描述    ：TransactionInterceptor
 *******************************************************************************/

using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CX4.Infrastructure.Service.AOP
{
    /// <summary>
    ///基于微软分布式事务拦截器
    /// </summary>
    public class TransactionInterceptor : IInterceptor
    {
        /// <summary>
        ///拦截方法
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            using (var tran = new System.Transactions.TransactionScope())
            {
                //执行被拦截的方法
                invocation.Proceed();
                tran.Complete();
            }
        }
    }
}
