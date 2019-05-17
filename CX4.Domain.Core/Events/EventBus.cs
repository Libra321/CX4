/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/16 9:45:42
 ****** 功能描述    ：EventBus
 *******************************************************************************/

using CX4.Infrastructure.Service.IOC;
using MediatR;
using System.Threading.Tasks;

namespace CX4.Domain.Core.Events
{
    /// <summary>
    ///基于MediatR的事件总线
    /// </summary>
    [Inject]
    public class EventBus : IEventBus
    {
        /// <summary>
        /// <see cref="IMediator"/>
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// 初始化<see cref="EventBus"/>的实例
        /// </summary>
        /// <param name="mediator"></param>
        public EventBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        /// <returns></returns>
        public Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            return _mediator.Publish(@event);
        }
    }
}
