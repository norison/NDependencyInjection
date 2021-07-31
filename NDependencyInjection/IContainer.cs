using System;

namespace NDependencyInjection
{
    public interface IContainer
    {
        T Resolve<T>();
    }
}