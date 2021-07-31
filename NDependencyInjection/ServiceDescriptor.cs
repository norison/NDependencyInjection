using System;

namespace NDependencyInjection
{
    public class ServiceDescriptor
    {
        public Type ServiceType { get; }
        public Type ImplementationType { get; }
        public object Implementation { get; set; }
        public ELifeTimeCycle LifeTimeCycle { get; }

        public ServiceDescriptor(Type serviceType, ELifeTimeCycle lifeTimeCycle)
        {
            ServiceType = serviceType;
            LifeTimeCycle = lifeTimeCycle;
        }

        public ServiceDescriptor(Type serviceType, Type implementationType, ELifeTimeCycle lifeTimeCycle) : this(serviceType, lifeTimeCycle)
        {
            ImplementationType = implementationType;
        }

        public ServiceDescriptor(Type serviceType, object implementation, ELifeTimeCycle lifeTimeCycle) : this(serviceType, lifeTimeCycle)
        {
            Implementation = implementation;
        }
    }
}