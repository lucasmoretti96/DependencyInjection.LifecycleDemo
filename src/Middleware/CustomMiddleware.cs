using DependencyInjection.LifecycleDemo.Interfaces;
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

        public async Task InvokeAsync(HttpContext context, IGuidServiceTransient _guidServiceTransient,
                                      IGuidServiceSingleton _guidServiceSingleton, IGuidServiceScoped _guidServiceScoped)
        {
            var logMessage = $"Middleware: The Guid from GuidServiceTransient is {_guidServiceTransient.GetGuid()}" +
                $"The Guid from GuidServiceSingleton is {_guidServiceSingleton.GetGuid()}" +
                $"The Guid from GuidServiceScoped is {_guidServiceScoped.GetGuid()}";

            _logger.LogInformation(logMessage);

            context.Items.Add("MiddlewareGuid", logMessage);

            await Task.WhenAll(_next(context));
        }
    }
}
