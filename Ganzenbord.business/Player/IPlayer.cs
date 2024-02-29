using Ganzenbord.Business.Logger;

namespace Ganzenbord.Business.Player
{
    public interface IPlayer
    {
        int AmountOfSkips { get; set; }
        PlayerColor Color { get; }
        bool IsWinner { get; set; }
        bool KeepSkipping { get; set; }
        ILogger Logger { get; }
        int Position { get; }

        void Move(int[] dice);

        void MoveToPosition(int position);

        int[] RollDice(int amountOfDice);

        void StartTurn();

        void TurnsToSkip(int amountOfSkips);
    }
}