using GuessTheNumber.Classes;

namespace GuessTheNumber.Interfaces
{
    public interface IGameLogic
    {
        GameResult CheckGuess(int secretNumber, int guess);
    }
}
