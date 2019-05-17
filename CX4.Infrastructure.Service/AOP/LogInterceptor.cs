/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/16 19:40:30
 ****** 功能描述    ：LogInterceptor
 *******************************************************************************/

using Castle.Core.Internal;
using Castle.DynamicProxy;
using CX4.Infrastructure.Service.Log;
using CX4.Infrastructure.Service.Utility;
using System;
using System.Text;

namespace CX4.Infrastructure.Service.AOP
{
    /// <summary>
    /// 日志拦截器
    /// </summary>
    public class LogInterceptor : InterceptorBase
    {
        private readonly ILog _log;
        private DateTime _startTime;

        /// <summary>
        ///
        /// </summary>
        /// <param name="log"></param>
        public LogInterceptor(ILog log)
        {
            _log = log;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="invocation"></param>
        protected override void InterceptBefore(IInvocation invocation)
        {
            var logAttribute = invocation.Method.GetAttribute<LogRecorderAttribute>();
            if (logAttribute != null)
            {
                if (logAttribute.IsRecordRequet)
                {
                    string param = invocation.Arguments.ToJson();
                    string methodInfo = $"{ invocation.TargetType.FullName }.{invocation.Method.Name}";
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"requestTargetMethod:{methodInfo}");
                    sb.Append("  ");
                    sb.Append($"requestParam:{param}");
                    _log.Debug(sb.ToString());
                }
            }
            _startTime = DateTime.Now;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="invocation"></param>
        protected override void InterceptAfter(IInvocation invocation)
        {
            var logAttribute = invocation.Method.GetAttribute<LogRecorderAttribute>();
            if (logAttribute != null)
            {
                if (logAttribute.IsRecordResponse || logAttribute.IsRecordExecuteTime)
                {
                    string methodInfo = $"{ invocation.TargetType.FullName }.{invocation.Method.Name}";
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"responseMethod:{methodInfo}");
                    if (logAttribute.IsRecordResponse)
                    {
                        sb.Append("  ");
                        string param = invocation.ReturnValue.ToJson();
                        sb.Append($"responseValue:{param}");
                    }
                    if (logAttribute.IsRecordExecuteTime)
                    {
                        sb.Append("  ");
                        var execTime = (DateTime.Now - _startTime).TotalMilliseconds;
                        sb.Append($"executeTime:{execTime}ms");
                    }
                    _log.Debug(sb.ToString());
                }
            }
        }
    }
}
