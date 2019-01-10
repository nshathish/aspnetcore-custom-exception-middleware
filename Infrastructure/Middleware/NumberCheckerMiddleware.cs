namespace aspnetcore_custom_exception_middleware.Infrastructure.Middleware
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class NumberCheckerMiddleware
    {
        private readonly RequestDelegate _next;

        public NumberCheckerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var value = context.Request.Query["value"].ToString();
            if (int.TryParse(value, out var intValue))
                await context.Response.WriteAsync($"You entered a number: {intValue}");
            else
            {
                context.Items["value"] = value;
                await _next(context);
            }
        }
    }
}
