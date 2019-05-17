/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/16 10:00:36
 ****** 功能描述    ：IEventHandler
 *******************************************************************************/

using MediatR;

namespace CX4.Domain.Core.Events
{
    /// <summary>
    ///事件处理接口
    /// </summary>
    public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
    {
    }
}
