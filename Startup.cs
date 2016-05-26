using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using ExceptionDemo;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace ExceptionDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var httpConfiguration = new HttpConfiguration();

            httpConfiguration.Services.Replace(typeof(IExceptionHandler), new ExampleExceptionHandler());
            httpConfiguration.Services.Add(typeof(IExceptionLogger), new ExampleExceptionLogger());
            
            httpConfiguration.MapHttpAttributeRoutes();
            httpConfiguration.EnableCors();
            
            appBuilder.UseOwinExceptionHandler();
            appBuilder.UseWebApi(httpConfiguration);
        }
    }
}