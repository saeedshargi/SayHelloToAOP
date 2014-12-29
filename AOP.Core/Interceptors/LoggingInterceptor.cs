using System;
using System.IO;
using AOP.Core.Logging;
using Castle.DynamicProxy;

namespace AOP.Core.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILogging _logging;

        public LoggingInterceptor(ILogging logging)
        {
            _logging = logging;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                _logging.Debug("Debuging OnStart!");
                invocation.Proceed();
                _logging.Debug("Debuging OnSuccess!");
            }
            catch (Exception exception)
            {
                _logging.Debug("Debuging OnError! :" + exception.Message);
                throw;
            }
            finally
            {
                _logging.Debug("Debugging OnExit!");
            }
        }
    }
}
