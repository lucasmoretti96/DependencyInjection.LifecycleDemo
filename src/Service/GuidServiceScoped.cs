using DependencyInjection.LifecycleDemo.Interfaces;
using System;

namespace DependencyInjection.LifecycleDemo.Service
{
    public class GuidServiceScoped : IGuidServiceScoped
    {
        private readonly Guid ServiceGuid;

        public GuidServiceScoped()
        {
            ServiceGuid = Guid.NewGuid();
        }

        public string GetGuid() => ServiceGuid.ToString();
    }
}
