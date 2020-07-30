using DependencyInjection.LifecycleDemo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DependencyInjection.LifecycleDemo.Controller
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly GuidServiceTransient _guidServiceTransient;
        private readonly GuidServiceSingleton _guidServiceSingleton;
        private readonly GuidServiceScoped _guidServiceScoped;
        private readonly ILogger<HomeController> _logger;

        public HomeController(GuidServiceTransient guidServiceTransient, GuidServiceSingleton guidServiceSingleton,
                              GuidServiceScoped guidServiceScoped, ILogger<HomeController> logger)
        {
            _guidServiceTransient = guidServiceTransient;
            _guidServiceSingleton = guidServiceSingleton;
            _guidServiceScoped = guidServiceScoped;
            _logger = logger;
        }

        [Route("")]
        public IActionResult Index()
        {
            var guidTransient = _guidServiceTransient.GetGuid();

            var guidSingleton = _guidServiceSingleton.GetGuid();

            var guidScoped = _guidServiceScoped.GetGuid();

            var logMessage = $"Controller: The Guid from GuidServiceTransient is {guidTransient}" +
                             $"The Guid from GuidServiceSingleton is {guidSingleton}" +
                             $"The Guid from GuidServiceScoped is {guidScoped}";

            _logger.LogInformation(logMessage);

            var messages = new List<string>
            {
                HttpContext.Items["MiddlewareGuid"].ToString(),
                logMessage
            };

            return Ok(messages);
        }
    }
}
