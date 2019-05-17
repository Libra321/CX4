/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/15 20:16:58
 ****** 功能描述    ：CommandBus
 *******************************************************************************/

using MediatR;
using System.Threading.Tasks;

namespace CX4.Domain.Core.Commands
{
    /// <summary>
    /// 基于MediatR的命令总线
    /// </summary>
    public class CommandBus : ICommandBus
    {
        /// <summary>
        /// <see cref="IMediator"/>
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// 初始化<see cref="CommandBus"/> 实例
        /// </summary>
        /// <param name="mediator"></param>
        public CommandBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///异步发送无返回值命令
        /// </summary>
        /// <typeparam name="TCommand">命令类型</typeparam>
        /// <param name="command">命令</param>
        /// <returns></returns>
        public async Task Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            await this._mediator.Send(command);
        }

        /// <summary>
        ///异步发送有返回值命令
        /// </summary>
        /// <typeparam name="TCommand">命令类型</typeparam>
        /// <typeparam name="TCommandResult">命令返回结果</typeparam>
        /// <param name="command">命令</param>
        /// <returns></returns>
        public async Task<TCommandResult> Send<TCommand, TCommandResult>(TCommand command) where TCommand : ICommand<TCommandResult>
        {
            return await this._mediator.Send(command);
        }
    }
}
