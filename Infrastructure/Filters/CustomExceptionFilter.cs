namespace aspnetcore_custom_exception_middleware.Infrastructure.Filters
{
    using System.Net;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class CustomExceptionFilter: IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var status = HttpStatusCode.InternalServerError;
            var message = context.Exception.Message;

            context.ExceptionHandled = true;

            var response = context.HttpContext.Response;
            response.StatusCode = (int) status;
            response.ContentType = "application/json";
            response.WriteAsync(new 
            {
                ErrorCode = (int)status,
                ErrorMessage = message,
                ErrorDescription = "This is handled by custom exception filter"
            }.ToString());
        }
    }
}
