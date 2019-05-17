/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/16 9:38:02
 ****** 功能描述    ：IEventBus
 *******************************************************************************/

using System.Threading.Tasks;

namespace CX4.Domain.Core.Events
{
    /// <summary>
    /// 事件总线接口
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        ///发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        /// <returns></returns>
        Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
