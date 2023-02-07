using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MicroLibrary.API
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        #region Constructor

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        #endregion

        #region Methods

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string message;
            string result;

            if (ex is ArgumentException)
            {
                message = ex.Message;
                status = HttpStatusCode.BadRequest;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = ex.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            result = JsonSerializer.Serialize(new { error = message, statusCode = status, ex.StackTrace });

            return context.Response.WriteAsync(result);
        }

        #endregion
    }
}
