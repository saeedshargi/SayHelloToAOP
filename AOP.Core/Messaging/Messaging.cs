using System;

namespace AOP.Core.Messaging
{
    public class Messaging : IMessaging
    {
        public void SayHello(string message)
        {
            Console.WriteLine(@"Hello to " + message);
        }
    }
}
