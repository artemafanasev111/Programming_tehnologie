namespace GuessTheNumber.Classes
{
    using GuessTheNumber.Interfaces;
    using System;

    public class ConsoleInput : IInput
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}