using Owin;

namespace ExceptionDemo
{
    public static class AppBuilderExtensions
    {
        public static void UseExceptionLogging(this IAppBuilder appBuilder)
        {
            appBuilder.Use(typeof(ExceptionMiddleware));
        }

        public static void UseOwinExceptionHandler(this IAppBuilder app)
        {
            app.Use<OwinExceptionHandlerMiddleware>();
        }
    }
}