/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/16 19:29:13
 ****** 功能描述    ：Log
 *******************************************************************************/

using CX4.Infrastructure.Service.IOC;
using NLog;
using NLog.Config;
using System;
using System.IO;

namespace CX4.Infrastructure.Service.Log
{
    /// <summary>
    ///基于NLog的默认日志
    /// </summary>
    [Inject]
    public class Log : ILog
    {
        private readonly static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///
        /// </summary>
        static Log()
        {
            string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Config\NLog.config");
            if (!File.Exists(logFile))
            {
                throw new FileNotFoundException("没有找到日志配置文件");
            }
            LogManager.Configuration = new XmlLoggingConfiguration(logFile);
        }

        /// <summary>
        ///诊断日志
        /// </summary>
        /// <param name="msg"></param>
        public void Trace(string msg)
        {
            if (logger.IsTraceEnabled)
            {
                logger.Trace(msg);
            }
        }

        /// <summary>
        ///调试日志
        /// </summary>
        /// <param name="msg"></param>
        public void Debug(string msg)
        {
            if (logger.IsDebugEnabled)
            {
                logger.Debug(msg);
            }
        }

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="msg"></param>
        public void Info(string msg)
        {
            if (logger.IsInfoEnabled)
            {
                logger.Debug(msg);
            }
        }

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="msg"></param>
        public void Warn(string msg)
        {
            if (logger.IsWarnEnabled)
            {
                logger.Warn(msg);
            }
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="msg"></param>
        public void Error(string msg)
        {
            if (logger.IsErrorEnabled)
            {
                logger.Error(msg);
            }
        }

        /// <summary>
        /// 致命日志
        /// </summary>
        /// <param name="msg"></param>
        public void Fatal(string msg)
        {
            if (logger.IsFatalEnabled)
            {
                logger.Fatal(msg);
            }
        }
    }
}
