/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/16 19:33:09
 ****** 功能描述    ：LogRecorderAttribute
 *******************************************************************************/

using System;

namespace CX4.Infrastructure.Service.AOP
{
    /// <summary>
    ///日志记录特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class LogRecorderAttribute : Attribute
    {
        /// <summary>
        ///是否记录请求信息
        /// </summary>
        public bool IsRecordRequet { get; set; } = false;

        /// <summary>
        ///是否记录响应信息
        /// </summary>
        public bool IsRecordResponse { get; set; } = false;

        /// <summary>
        ///是否记录执行时间
        /// </summary>
        public bool IsRecordExecuteTime { get; set; } = false;
    }
}
