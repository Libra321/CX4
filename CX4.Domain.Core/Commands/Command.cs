/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/15 20:05:18
 ****** 功能描述    ：Command
 *******************************************************************************/

using CX4.Domain.Core.Events;
using MediatR;

namespace CX4.Domain.Core.Commands
{
    /// <summary>
    /// 无返回值得结果命令基类
    /// </summary>
    public abstract class Command : Command<Unit>, ICommand
    {
    }

    /// <summary>
    /// 有返回值的结果命令基类
    /// </summary>
    /// <typeparam name="TCommandResult"></typeparam>
    public abstract class Command<TCommandResult> : Message, ICommand<TCommandResult>
    {
    }
}
