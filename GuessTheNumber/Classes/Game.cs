namespace GuessTheNumber.Classes
{
    using GuessTheNumber.Interfaces;
    using System;

    public class Game
    {
        private readonly IGenerator _generator;
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly IGameLogic _gameLogic;
        private readonly int _minNumber;
        private readonly int _maxNumber;
        private int _attemptsLeft;
        private readonly int _maxAttempts; // Добавляем приватное поле для хранения maxAttempts

        public Game(IGenerator generator, IInput input, IOutput output, IGameLogic gameLogic, int minNumber, int maxNumber, int maxAttempts)
        {
            _generator = generator;
            _input = input;
            _output = output;
            _gameLogic = gameLogic;
            _minNumber = minNumber;
            _maxNumber = maxNumber;
            _attemptsLeft = maxAttempts;
            _maxAttempts = maxAttempts; // Инициализируем приватное поле
        }

        public void Play()
        {
            int secretNumber = _generator.Generate(_minNumber, _maxNumber);
            _output.WriteLine($"Я загадал число от {_minNumber} до {_maxNumber}. Попробуй угадать!");

            while (_attemptsLeft > 0)
            {
                _output.WriteLine($"У тебя осталось {_attemptsLeft} попыток.");
                _output.WriteLine("Введи свою догадку:");
                string input = _input.GetInput();

                if (int.TryParse(input, out int guess))
                {
                    _attemptsLeft--;
                    GameResult result = _gameLogic.CheckGuess(secretNumber, guess);

                    switch (result)
                    {
                        case GameResult.Lower:
                            _output.WriteLine("Загаданное число больше.");
                            break;
                        case GameResult.Higher:
                            _output.WriteLine("Загаданное число меньше.");
                            break;
                        case GameResult.Correct:
                            _output.WriteLine($"Поздравляю! Ты угадал число {secretNumber} за {_maxAttempts - _attemptsLeft} попыток.");
                            return;
                    }
                }
                else
                {
                    _output.WriteLine("Некорректный ввод. Пожалуйста, введи число.");
                }
            }

            _output.WriteLine($"Ты проиграл! Загаданное число было {secretNumber}.");
        }
    }
}