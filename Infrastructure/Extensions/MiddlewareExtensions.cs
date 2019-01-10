namespace aspnetcore_custom_exception_middleware.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Middleware;

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseNumberChecker(this IApplicationBuilder app) =>
            app.UseMiddleware<NumberCheckerMiddleware>();

        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app) =>
            app.UseMiddleware<ExceptionMiddleware>();
    }
}
