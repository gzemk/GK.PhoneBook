using GK.PhoneBook.API.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace GK.PhoneBook.API.Exceptions
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        static readonly ILogger Log = (ILogger)Serilog.Log.ForContext<ExceptionMiddleware>();

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            
        }

        private Task HandleExceptionAsync(HttpContext httpContext,  Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string result = JsonConvert.SerializeObject(new ExceptionModel
            {
                Message = ex.Message,
                StatusCode = httpContext.Response.StatusCode
            });

            //TO DO Seri Log 
            var dateTime = DateTime.UtcNow;
            Log.LogError($"{dateTime.ToString("HH:mm:ss")} : {ex}");

            return httpContext.Response.WriteAsync(result);
        }
    }
}
