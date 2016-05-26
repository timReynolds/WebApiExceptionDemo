using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace ExceptionDemo
{
    public class ExampleExceptionLogger : IExceptionLogger
    {
        public async Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"Example Exception Logger {context}");
            });
        }
    }
}