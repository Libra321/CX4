/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/15 20:07:15
 ****** 功能描述    ：Message
 *******************************************************************************/

using System;

namespace CX4.Domain.Core.Events
{
    /// <summary>
    ///消息抽象基类
    /// </summary>
    public abstract class Message : IMessage
    {
        /// <summary>
        ///
        /// </summary>
        public Guid ID { get; private set; } = Guid.NewGuid();

        /// <summary>
        ///
        /// </summary>
        public DateTime Timestamp { get; private set; } = DateTime.Now;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public string MessageType() => this.GetType().FullName;
    }
}
