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
        public bool ActiveGame {  get; private set; }=true;
        public Player[] Players { get; private set; }
        public GameProgression(ILogger logger)
        {
            this.logger = logger;
        }
        public void StartGame(Player[] players)
        {
            Players = players;
            Game.Instance.ResetGame();
            while (ActiveGame)
            {
                Game.Instance.PlayRound(Players);
            }
        }
        public void StopGame()
        {
            ActiveGame = false;
            logger.Log("The game has ended.");
        }

    }
}
