using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace ExceptionDemo
{
    public class ExampleExceptionHandler : IExceptionHandler
    {
        public async Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"Example Exception Handler {context}");
            });
        }
    }
}