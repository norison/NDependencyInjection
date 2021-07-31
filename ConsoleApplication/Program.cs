using System;
using NDependencyInjection;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterTransient<IRandomNumberGenerator, RandomNumberGenerator>();
            containerBuilder.RegisterTransient<IGenerator, Generator>();
            var container = containerBuilder.Build();

            var first = container.Resolve<IRandomNumberGenerator>();
            var second = container.Resolve<IRandomNumberGenerator>();

            Console.WriteLine($"First: {first.Number}");
            Console.WriteLine($"Second: {second.Number}");

            Console.ReadKey();
        }
    }
}
