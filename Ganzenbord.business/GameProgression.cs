using Ganzenbord.Business.Logger;

namespace Ganzenbord.Business
{
    public class GameProgression
    {
        private ILogger logger;
        public Player[] Players { get; private set; }


        public GameProgression(ILogger logger)
        {
            this.logger = logger;
        }

        public void StartGame(Player[] players)
        {
            Players = players;

            Game.Instance.StartGame();
            while (Game.Instance.ActiveGame)
            {
                PlayRound(Players);
            }
            logger.Log("End Results: ");
            foreach (Player player in Players)
            {
                logger.Log($"{player.Color}: {player.Position}");
            }
            StopGame();
        }

        public void PlayRound(Player[] players)
        {
            logger.Log($"Start round: {Game.Instance.Turn}");
            foreach (Player player in players)
            {
                player.StartTurn();
                logger.Log($"{player.Color}: {player.Position}\n");
            }
            Game.Instance.Turn++;
        }

        public void StopGame()
        {
            Game.Instance.StopGame();
            logger.Log("The game has ended.");
        }
    }
}