using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace MarsRover.Core.Abstraction.Exceptions
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            //catch (Exception ex) when (ex is CoreLayerException || ex is BusinessException)
            //{
            //    await ManipulateResponse(httpContext, ex.Message, HttpStatusCode.BadRequest);
            //}
            //catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException)
            //{
            //    var argumentException = ex as ArgumentException;
            //    await ManipulateResponse(httpContext, $"{ex.Message} parametre:{argumentException.ParamName}", HttpStatusCode.BadRequest);
            //}
            catch (ValidationException ex)
            {
                await ManipulateResponse(httpContext, ex.ValidationResult.ErrorMessage, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                await ManipulateResponse(httpContext, "Burada bir şeyler ters gitti.", HttpStatusCode.InternalServerError);
            }
        }

        private async Task ManipulateResponse(HttpContext context, string message, HttpStatusCode statusCode)
        {
            var result = JsonConvert.SerializeObject(message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(result);
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
