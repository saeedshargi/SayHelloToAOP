using System;
using AOP.Core.Logging;
using AOP.Core.Messaging;
using Autofac;

namespace AOP
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Log>().As<ILogging>().InstancePerLifetimeScope();
            builder.RegisterType<Messaging>().As<IMessaging>().InstancePerLifetimeScope();
            var container = builder.Build();
            var log = container.Resolve<ILogging>();
            var message = container.Resolve<IMessaging>();
            try
            {
                log.Debug("Debuging Started!");
                message.SayHello("Tabriz Software OpenTalks!");
                log.Debug("Debuging Successed!");
            }
            catch (Exception exception)
            {
                log.Debug("Debuging Raise Error: " + exception.Message);
                throw;
            }
            finally
            {
                log.Debug("Debuging Ended!");
                Console.ReadKey();
            }
        }
    }
}
