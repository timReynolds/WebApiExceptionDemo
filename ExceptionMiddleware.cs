﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace ExceptionDemo
{
    public class ExceptionMiddleware : OwinMiddleware
    {
        public ExceptionMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception exception)
            {
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                context.Response.ReasonPhrase = "Error processing request within the middleware";
            }
        }
    }
}