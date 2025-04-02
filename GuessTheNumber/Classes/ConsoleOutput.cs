namespace GuessTheNumber.Classes
{
    using GuessTheNumber.Interfaces;
    using System;

    public class ConsoleOutput : IOutput
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}