using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;

namespace Ganzenbord.Business
{
    public class GameProgression
    {
        private ILogger logger;
        public IPlayer[] Players { get; private set; }

        public GameProgression(ILogger logger)
        {
            this.logger = logger;
        }

        public void StartGame(IPlayer[] players)
        {
            Players = players;

            Game.Instance.StartGame();
            while (Game.Instance.ActiveGame)
            {
                PlayRound(Players);
            }
            logger.Log("End Results: ");
            foreach (IPlayer player in Players)
            {
                logger.Log($"{player.Color}: {player.Position}");
            }
        }

        public void PlayRound(IPlayer[] players)
        {
            logger.Log($"Start round: {Game.Instance.Turn}");
            foreach (IPlayer player in players)
            {
                if (player.IsWinner)
                {
                    StopGame();
                    break;
                }
                //player.StartTurn();
                logger.Log($"{player.Color}: {player.Position}\n");
            }
            Game.Instance.Turn++;
        }

        public void StopGame()
        {
            Game.Instance.ActiveGame = false;
            //Game.Instance.Ac; Met winnaar aanduiden dat het spel gedaan is
            logger.Log("The game has ended.");
        }
    }
}