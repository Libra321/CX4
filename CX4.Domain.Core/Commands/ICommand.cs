/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/15 19:54:27
 ****** 功能描述    ：ICommand
 *******************************************************************************/

using CX4.Domain.Core.Events;
using MediatR;

namespace CX4.Domain.Core.Commands
{
    /// <summary>
    /// 基于MediatR的无返回值请求响应命令接口
    /// </summary>
    public interface ICommand : IRequest
    {
    }

    /// <summary>
    /// 基于MediatR的有回值请求响应命令接口
    /// </summary>
    public interface ICommand<out TCommandResult> : IRequest<TCommandResult>, IMessage
    {
    }
}
