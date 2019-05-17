/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/16 19:27:30
 ****** 功能描述    ：ILog
 *******************************************************************************/

namespace CX4.Infrastructure.Service.Log
{
    /// <summary>
    ///日志接口
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 诊断
        /// </summary>
        /// <param name="msg"></param>
        void Trace(string msg);

        /// <summary>
        ///调试
        /// </summary>
        /// <param name="msg"></param>
        void Debug(string msg);

        /// <summary>
        ///信息
        /// </summary>
        /// <param name="msg"></param>
        void Info(string msg);

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="msg"></param>
        void Warn(string msg);

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="msg"></param>
        void Error(string msg);

        /// <summary>
        /// 致命
        /// </summary>
        /// <param name="msg"></param>
        void Fatal(string msg);
    }
}
