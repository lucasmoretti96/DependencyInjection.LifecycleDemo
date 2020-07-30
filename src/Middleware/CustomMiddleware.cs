using DependencyInjection.LifecycleDemo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DependencyInjection.LifecycleDemo.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _logger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, GuidServiceTransient guidServiceTransient,
                                      GuidServiceSingleton guidServiceSingleton, GuidServiceScoped guidServiceScoped)
        {
            var logMessage = $"Middleware: The Guid from GuidServiceTransient is {guidServiceTransient.GetGuid()}" +
                $"The Guid from GuidServiceSingleton is {guidServiceSingleton.GetGuid()}" +
                $"The Guid from GuidServiceScoped is {guidServiceScoped.GetGuid()}";

            _logger.LogInformation(logMessage);

            context.Items.Add("MiddlewareGuid", logMessage);

            await _next(context);
        }
    }
}
