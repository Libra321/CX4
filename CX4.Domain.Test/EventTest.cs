using Autofac;
using Autofac.Extras.DynamicProxy;
using CX4.Domain.Core.Events;
using CX4.Infrastructure.Service.AOP;
using CX4.Infrastructure.Service.IOC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CX4.Domain.Test
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void Event()
        {
            Autofac.ContainerBuilder build = new Autofac.ContainerBuilder();
            var ioc = ContainerManage.Register(build);
            var bus = ioc.Resolve<IEventBus>();
            bus.Publish(new Event1());
            bus.Publish(new Event2());
        }
    }

    public class Event1 : Event
    {
        public string Name { get; }

        public Event1()
        {
            this.Name = nameof(Event1);
        }
    }

    public class Event2 : Event
    {
        public string Name { get; }

        public Event2()
        {
            this.Name = nameof(Event2);
        }
    }

    [Inject]
    [Intercept(typeof(LogInterceptor))]
    public class Event2Handler : IEventHandler<Event1>, IEventHandler<Event2>
    {
        /// <summary>
        ///
        /// </summary>
        ///
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [LogRecorder(IsRecordExecuteTime = true, IsRecordRequet = true, IsRecordResponse = true)]
        public virtual Task Handle(Event1 notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Event1_1");
            return Task.FromResult(true);
        }

        public virtual Task Handle(Event2 notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Event2_2");
            return Task.FromResult(true);
        }
    }
}
