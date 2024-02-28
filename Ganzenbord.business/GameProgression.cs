using Ganzenbord.Business.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord.Business
{
    public class GameProgression
    {
        ILogger logger;
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
                Game.Instance.PlayRound(Players);
            }
        }
        public void StopGame()
        {
            Game.Instance.StopGame();
            logger.Log("The game has ended.");
        }

    }
}
