/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/15 20:13:13
 ****** 功能描述    ：ICommandBus
 *******************************************************************************/

using System.Threading.Tasks;

namespace CX4.Domain.Core.Commands
{
    /// <summary>
    /// 命令总线接口
    /// </summary>
    public interface ICommandBus
    {
        /// <summary>
        ///发送命令
        /// </summary>
        /// <typeparam name="TCommand">命令类型</typeparam>
        /// <param name="command">命令</param>
        /// <returns></returns>
        Task Send<TCommand>(TCommand command) where TCommand : ICommand;

        /// <summary>
        ///发送命令
        /// </summary>
        /// <typeparam name="TCommand">命令类型</typeparam>
        /// <typeparam name="TCommandResult">命令返回结果</typeparam>
        /// <param name="command">命令</param>
        /// <returns></returns>
        Task<TCommandResult> Send<TCommand, TCommandResult>(TCommand command) where TCommand : ICommand<TCommandResult>;
    }
}
