using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type serviceType)
        {
            var typeName = serviceType.Name;

            if (!_serviceDescriptors.ContainsKey(typeName))
            {
                throw new Exception($"The '{typeName}' is not registered");
            }

            var descriptor = _serviceDescriptors[typeName];

            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("Cannot instantiate abstract class or interface");
            }

            var parameters = actualType
                .GetConstructors()
                .First()
                .GetParameters()
                .Select(x => Resolve(x.ParameterType))
                .ToArray();

            var implementation = Activator.CreateInstance(actualType, parameters);

            if (descriptor.LifeTimeCycle == ELifeTimeCycle.Singleton)
            {
                descriptor.Implementation = implementation;
            }

            return implementation;
        }
    }
}