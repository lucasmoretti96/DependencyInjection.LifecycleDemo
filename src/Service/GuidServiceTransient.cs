using System;

namespace DependencyInjection.LifecycleDemo.Service
{
    public class GuidServiceTransient
    {
        private readonly Guid ServiceGuid;

        public GuidServiceTransient()
        {
            ServiceGuid = Guid.NewGuid();
        }

        public string GetGuid() => ServiceGuid.ToString();
    }
}
