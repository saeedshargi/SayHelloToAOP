using System;

namespace AOP.Core.Logging
{
    public class Log : ILogging
    {
        public void Debug(string message)
        {
            Console.WriteLine(message);
        }
    }
}
