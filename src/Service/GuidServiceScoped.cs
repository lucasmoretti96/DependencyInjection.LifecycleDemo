using System;

namespace DependencyInjection.LifecycleDemo.Service
{
    public class GuidServiceScoped
    {
        private readonly Guid ServiceGuid;

        public GuidServiceScoped()
        {
            ServiceGuid = Guid.NewGuid();
        }

        public string GetGuid() => ServiceGuid.ToString();
    }
}
