namespace NeuralNetwork
{
    using System;

    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random _random = new Random();

        public double Next()
        {
            return _random.NextDouble();
        }
    }
}