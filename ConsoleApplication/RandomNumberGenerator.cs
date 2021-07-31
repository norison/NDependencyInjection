using System;

namespace ConsoleApplication
{
    public interface IRandomNumberGenerator
    {
        int Number { get; set; }
    }

    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int Number { get; set; } = new Random().Next(0, 100);
    }
}