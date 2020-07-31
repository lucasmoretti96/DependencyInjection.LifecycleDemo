using DependencyInjection.LifecycleDemo.Interfaces;
using DependencyInjection.LifecycleDemo.Middleware;
using DependencyInjection.LifecycleDemo.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.LifecycleDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGuidServiceTransient, GuidServiceTransient>();
            services.AddSingleton<IGuidServiceSingleton, GuidServiceSingleton>();
            services.AddScoped<IGuidServiceScoped, GuidServiceScoped>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<CustomMiddleware>();

            app.UseRouting();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
