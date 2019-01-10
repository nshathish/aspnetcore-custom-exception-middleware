
namespace aspnetcore_custom_exception_middleware
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCustomExceptionHandler();
            app.Map("/ski", skiApp => skiApp.Run(async context => await context.Response.WriteAsync("Skip the line")));
            app.UseNumberChecker();
            app.Use(async (context, next) =>
            {
                // await context.Response.WriteAsync("This is middleware 1");
                context.Items["from_middleware_1"] = "Passed From Middleware 1";
                // calling next after response has been sent to client is prone to errros. Please see the ReadME
                await next();
            });
            app.Use(async (context, next) =>
            {
                var item = context.Items["from_middleware_1"].ToString();
                /*await context.Response.WriteAsync(
                    $"<br>This is middleware 2, and value passed from middleware 1: {item}");*/
                await next();
            });

            app.UseHttpsRedirection();
            app.UseMvc();

            app.Run(async context => await context.Response.WriteAsync("<br>This is immediately short circuit the request pipeline."));
        }
    }
}
