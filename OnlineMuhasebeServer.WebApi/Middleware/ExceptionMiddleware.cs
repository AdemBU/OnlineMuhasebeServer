
using FluentValidation;

namespace OnlineMuhasebeServer.WebApi.Middleware
{
    public sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;

            if (ex.GetType() == typeof(ValidationException))
            {
                return context.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = context.Response.StatusCode,
                    Errors = ((ValidationException)ex).Errors.Select(e => e.PropertyName)
                }.ToString());
            }

            return context.Response.WriteAsync(new ErrorResult
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            }.ToString());
        }
    }
}
