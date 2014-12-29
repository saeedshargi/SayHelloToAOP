using System;
using AOP.Core.Interceptors;
using AOP.Core.Logging;
using AOP.Core.Messaging;
using Autofac;
using Autofac.Extras.DynamicProxy2;

namespace AOP.DynamicProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Log>().As<ILogging>().InstancePerLifetimeScope();
            builder.RegisterType<Messaging>()
                .As<IMessaging>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (LoggingInterceptor));
            builder.Register(c => new LoggingInterceptor(new Log()));
            var container = builder.Build();
            var messaging = container.Resolve<IMessaging>();
            messaging.SayHello("Tabriz Software OpenTalks!");
            Console.ReadKey();
        }
    }
}
