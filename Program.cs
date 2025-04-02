using GuessTheNumber.Classes;
using GuessTheNumber.Interfaces;

namespace GuessTheNumber // Если вы решили добавить пространство имен в Program.cs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Настройка игры
            int minNumber = 1;
            int maxNumber = 100;
            int maxAttempts = 10;

            // Создание экземпляров конкретных классов
            IGenerator generator = new RandomNumberGenerator();
            IInput input = new ConsoleInput();
            IOutput output = new ConsoleOutput();
            IGameLogic gameLogic = new GuessingGameLogic();

            // Внедрение зависимостей через конструктор
            Game game = new Game(generator, input, output, gameLogic, minNumber, maxNumber, maxAttempts);

            // Запуск игры
            game.Play();
        }
    }
}