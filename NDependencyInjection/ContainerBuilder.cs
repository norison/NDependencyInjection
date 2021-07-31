using System.Collections.Generic;

namespace NDependencyInjection
{
    public class ContainerBuilder
    {
        private readonly Dictionary<string, ServiceDescriptor> _serviceDescriptors = new();


        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(typeof(TService).Name, new ServiceDescriptor(typeof(TService), typeof(TImplementation), ELifeTimeCycle.Singleton));
        }

        public void RegisterSingleton<TService>()
        {
            _serviceDescriptors.Add(typeof(TService).Name, new ServiceDescriptor(typeof(TService), ELifeTimeCycle.Singleton));
        }

        public void RegisterSingleton<TService>(TService implementation)
        {
            _serviceDescriptors.Add(typeof(TService).Name, new ServiceDescriptor(typeof(TService), implementation, ELifeTimeCycle.Singleton));
        }

        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(typeof(TService).Name, new ServiceDescriptor(typeof(TService), typeof(TImplementation), ELifeTimeCycle.Transient));
        }

        public void RegisterTransient<TService>()
        {
            _serviceDescriptors.Add(typeof(TService).Name, new ServiceDescriptor(typeof(TService), ELifeTimeCycle.Transient));
        }

        public void RegisterTransient<TService>(TService implementation)
        {
            _serviceDescriptors.Add(typeof(TService).Name, new ServiceDescriptor(typeof(TService), implementation, ELifeTimeCycle.Transient));
        }

        public IContainer Build()
        {
            return new Container(_serviceDescriptors);
        }
    }
}