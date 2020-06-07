using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AppSample.WebUI.Common
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            string status = "error";
            string message = "Internal error";

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var errorId = Guid.NewGuid();

            var result = JsonConvert.SerializeObject(new { error = message, status, id = errorId });

            _logger.LogError(exception, $"{errorId} {message}");

            return context.Response.WriteAsync(result);
        }
    }
}
