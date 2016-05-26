﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;


namespace ExceptionDemo
{
    public class OwinExceptionHandlerMiddleware
    {
        private readonly AppFunc _next;

        public OwinExceptionHandlerMiddleware(AppFunc next)
        {
            if (next == null)
            {
                throw new ArgumentNullException("next");
            }

            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            try
            {
                await _next(environment);
            }
            catch (Exception ex)
            {
                try
                {
                    var owinContext = new OwinContext(environment);
                    HandleException(ex, owinContext);
                    return;
                }
                catch (Exception)
                {
                    // If there's a Exception while generating the error page, re-throw the original exception.
                }
                throw;
            }
        }
        private void HandleException(Exception ex, IOwinContext context)
        {
            //var request = context.Request;
            //Build a model to represet the error for the client
            //var errorDataModel = NLogLogger.BuildErrorDataModel(ex);
            //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //context.Response.ReasonPhrase = "Internal Server Error";
            //context.Response.ContentType = "application/json";
            //context.Response.Write(JsonConvert.SerializeObject(errorDataModel));
        }
    }
}