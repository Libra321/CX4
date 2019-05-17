using Autofac;
using CX4.Domain.Core.Commands;
using CX4.Infrastructure.Service.IOC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace CX4.Domain.Test
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void Command()
        {
            ContainerBuilder build = new ContainerBuilder();
            var ioc = ContainerManage.Register(build);
            var bus = ioc.Resolve<ICommandBus>();
            var resp = bus.Send<Command1, Command1Result>(new Command1());
        }
    }

    public class Command1 : Command<Command1Result>
    {
        public string Name { get; }

        public Command1()
        {
            this.Name = nameof(Command1);
        }
    }

    [Inject]
    public class Command1Handler : ICommandHandler<Command1, Command1Result>
    {
        public async Task<Command1Result> Handle(Command1 request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Command1Result { Name = "pengdong" });
        }
    }

    public class Command1Result
    {
        public string Name { get; set; }
    }
}
