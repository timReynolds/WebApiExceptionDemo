using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using ExceptionDemo;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
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
            
            appBuilder.UseOwinExceptionHandler();
            appBuilder.UseCors(CorsOptions.AllowAll); // Use Owin Cors
            appBuilder.UseWebApi(httpConfiguration);
        }
    }
}