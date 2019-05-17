/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/16 9:33:55
 ****** 功能描述    ：IEvent
 *******************************************************************************/

using MediatR;

namespace CX4.Domain.Core.Events
{
    /// <summary>
    ///事件接口
    /// </summary>
    public interface IEvent : INotification, IMessage
    {
    }
}
