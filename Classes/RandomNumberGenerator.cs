namespace GuessTheNumber.Classes
{
    using GuessTheNumber.Interfaces;
    using System;

    public class RandomNumberGenerator : IGenerator
    {
        private readonly Random _random = new Random();

        public int Generate(int min, int max)
        {
            return _random.Next(min, max + 1);
        }
    }
}
