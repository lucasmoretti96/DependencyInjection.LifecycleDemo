using DependencyInjection.LifecycleDemo.Interfaces;
using System;

namespace DependencyInjection.LifecycleDemo.Service
{
    public class GuidServiceSingleton : IGuidServiceSingleton
    {
        private readonly Guid ServiceGuid;

        public GuidServiceSingleton()
        {
            ServiceGuid = Guid.NewGuid();
        }

        public string GetGuid() => ServiceGuid.ToString();
    }
}
