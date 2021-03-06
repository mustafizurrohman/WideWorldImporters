﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using WideWorldImporters.Logger.Interfaces;
using WideWorldImporters.Middleware.Base;

namespace WideWorldImporters.Middleware.ExceptionHandler
{

    /// <summary>
    /// Exception Handler
    /// </summary>
    public class ExceptionHandler : BaseMiddleware
    {

        /// <summary>
        /// Current hosting environment
        /// </summary>
        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// Logger
        /// </summary>
        private IWWILogger Logger => GetAppLogger();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestDelegate">Request Delegate</param>
        /// <param name="hostingEnvironment">Hosting Environment</param>
        /// <param name="serviceProvider">ServiceProvider required Dependency Injection (DI)</param>
        public ExceptionHandler(RequestDelegate requestDelegate, IHostingEnvironment hostingEnvironment, IServiceProvider serviceProvider)
            : base(requestDelegate, serviceProvider)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Middleware Implementation
        /// </summary>
        /// <param name="context">Http Context</param>
        /// <returns></returns>
        public override async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception ex)
            {
                try
                {
                    await HandleExceptionAsync(context, ex);
                }
                catch (Exception loggingException)
                {
                    // TODO: Inform dev ops team about this
                    Logger.LogException(loggingException);
                }
            }
        }

        /// <summary>
        /// Async handling of exception
        /// </summary>
        /// <param name="context">Http Context</param>
        /// <param name="ex">Exception</param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // NOTE: _logger.Log and _logger.LogException calls the same function!
            // This is just to demonstrate that we can handle exception differently based on the hosting environment

            // BackgroundJob.Enqueue(() => Console.WriteLine("Hello, world!"));

            if (_hostingEnvironment.IsDevelopment())
            {
                // Handle Exception in development mode
                // Do no make the user wait for the logging to finish. Do it in background.
                Task.Run(() => Logger.Log(ex));
                // BackgroundJob.Enqueue(() => Logger.Log(ex));

            }
            else
            {
                // Handle Exception when not in development mode (Staging or Production)
                // Do no make the user wait for the logging to finish. Do it in background.
                Task.Run(() => Logger.LogException(ex));
                // BackgroundJob.Enqueue(() => Logger.LogException(ex));
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(ex.Message);
        }

    }
}
