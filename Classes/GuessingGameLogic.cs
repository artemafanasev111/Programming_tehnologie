namespace GuessTheNumber.Classes
{
    using GuessTheNumber.Interfaces;

    public enum GameResult
    {
        Lower,
        Higher,
        Correct
    }

    public class GuessingGameLogic : IGameLogic
    {
        public GameResult CheckGuess(int secretNumber, int guess)
        {
            if (guess < secretNumber)
            {
                return GameResult.Lower;
            }
            else if (guess > secretNumber)
            {
                return GameResult.Higher;
            }
            else
            {
                return GameResult.Correct;
            }
        }
    }
}