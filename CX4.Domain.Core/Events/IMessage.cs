/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/15 20:01:28
 ****** 功能描述    ：IMessage
 *******************************************************************************/

using System;

namespace CX4.Domain.Core.Events
{
    /// <summary>
    ///消息接口
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        ///
        /// </summary>
        Guid ID { get; }

        /// <summary>
        ///时间戳
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        ///当前信息类型
        /// </summary>
        /// <returns></returns>
        string MessageType();
    }
}
