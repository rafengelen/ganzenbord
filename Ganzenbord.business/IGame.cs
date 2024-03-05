using Ganzenbord.Business.Player;

namespace Ganzenbord.Business
{
    public interface IGame
    {
        bool ActiveGame { get; set; }
        bool IsValidGame { get; set; }
        IPlayer[] Players { get; set; }
        int Turn { get; set; }

        void HandleFirstRound(IPlayer player, int[] dice);
        void PlayGame();
        void PlayRound();
        void StartGame();
        void StopGame();
        bool ValidPlayers(int amountOfPlayers);
    }
}