using System;

namespace ConsoleApplication
{
    public interface IGenerator
    {
        int Generate();
    }

    public class Generator : IGenerator
    {
        public int Generate()
        {
           return new Random().Next(0, 100);
        }
    }
}