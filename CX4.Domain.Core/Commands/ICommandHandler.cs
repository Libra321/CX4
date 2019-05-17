/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/16 9:26:52
 ****** 功能描述    ：ICommandHandler
 *******************************************************************************/

using MediatR;

namespace CX4.Domain.Core.Commands
{
    /// <summary>
    /// 无返回值命令处理接口
    /// </summary>
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {
    }

    /// <summary>
    /// 有返回值命令处理接口
    /// </summary>
    public interface ICommandHandler<in TCommand, TCommandResult> : IRequestHandler<TCommand, TCommandResult> where TCommand : ICommand<TCommandResult>
    {
    }
}
