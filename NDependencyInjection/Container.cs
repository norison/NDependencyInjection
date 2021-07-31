using System;
using System.Collections.Generic;

namespace NDependencyInjection
{
    public class Container : IContainer
    {
        private readonly Dictionary<string, ServiceDescriptor> _serviceDescriptors;

        public Container(Dictionary<string, ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }

        public T Resolve<T>()
        {
            var typeName = typeof(T).Name;

            if (!_serviceDescriptors.ContainsKey(typeName))
            {
                throw new Exception($"The '{typeName}' is not registered");
            }

            var descriptor = _serviceDescriptors[typeName];

            if (descriptor.Implementation != null)
            {
                return (T)descriptor.Implementation;
            }

            var implementation = Activator.CreateInstance(descriptor.ImplementationType ?? descriptor.ServiceType);

            if (descriptor.LifeTimeCycle == ELifeTimeCycle.Singleton)
            {
                descriptor.Implementation = implementation;
            }

            return (T)implementation;
        }
    }
}