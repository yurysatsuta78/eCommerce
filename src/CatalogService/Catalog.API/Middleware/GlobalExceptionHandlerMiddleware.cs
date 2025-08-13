using System.Net;
using Catalog.BLL.Exceptions;

namespace Catalog.API.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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
            context.Response.ContentType = "application/json";
            int statusCode;

            switch (exception)
            {
                case ArgumentException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case CatalogDomainException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case EntityNotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;
                case InvalidOperationException:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.StatusCode = statusCode;

            var response = new
            {
                exceptionMessage = exception.Message,
                exceptionDetails = exception.StackTrace
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
