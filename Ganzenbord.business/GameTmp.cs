using Ganzenbord.Business.Factory;
using Ganzenbord.Business.GameBoard;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;
using System.Drawing;
using System;
using System.Numerics;

namespace Ganzenbord.Business
{
    public class GameTmp
    {
        private Random random = new Random();
        public int Turn { get; set; } = 1;
        public bool ActiveGame { get; set; } = false;
        private int AmountOfDice { get; set; }
        public IGameBoard GameBoard { get; set; } = GameBoardFactory.Create(GameBoardType.GooseGame);
        private ILogger logger;
        public IPlayer[] Players { get; }

        public GameTmp(ILogger logger, IPlayer[] players, GameBoardType boardType, int amountOfDice = 2)
        {
            this.logger = logger;
            Players = players;
            GameBoard = GameBoardFactory.Create(boardType);
            AmountOfDice = amountOfDice;
        }

        public bool ValidPlayers(IPlayer[] players)
        {
            int AmountOfDifferentColors = players.Select(player => player.Color).Distinct().Count();
            if (players.Length > 4)
            {
                logger.Log($"{players.Length} are too many players, this game can be played with max 4 players.");
                return false;
            }
            else if (AmountOfDifferentColors != players.Length)
            {
                logger.Log("Players have duplicate color, choose a different color for each player.");
                return false;
            }
            return true;
        }

        public void StartGame()
        {
            if (ValidPlayers(Players))
            {
                ActiveGame = true;
                string playerColors = string.Join(", ", Players.Select(player => player.Color));
                logger.Log($"Game Starts with {Players.Length} players: {playerColors}\n");
                PlayGame();
            }
            logger.Log("Shutdown Game");
        }

        public void StopGame()
        {
            ActiveGame = false;
        }

        public void PlayGame()
        {
            while (ActiveGame)
            {
                PlayRound();
            }
            logger.Log($"\nDuration Game: {Turn} rounds\nEnd Results: ");
            foreach (IPlayer player in Players)
            {
                logger.Log($"{player.Color}: {player.Position}");
            }
        }

        public void PlayRound()
        {
            logger.Log($"Start round: {Turn}\n");
            foreach (IPlayer player in Players)
            {
                logger.Log($"{player.Color} player");
                
                int[] dice = RollDice(AmountOfDice);
                if (!player.KeepSkipping || player.AmountOfSkips > 0)
                {
                    logger.Log($"Dice rolls: {string.Join(", ", dice)}");
                }
                if (Turn == 1 && dice.Sum() == 9)
                {
                    HandleFirstRound(player, dice); ;
                }
                else
                {
                    
                    player.StartTurn(dice);
                    
                }
                
                logger.Log($"Position: {player.Position}\n");
                if (player.IsWinner)
                {
                    StopGame();
                    break;
                }
            }
            if (ActiveGame)
            {
                Turn++;
            }
            
        }
        public int[] RollDice(int amountOfDice)
        {
            int[] dice = new int[amountOfDice];
            for (int i = 0; i < amountOfDice; i++)
            {
                dice[i] = random.Next(1, 7);
            }
            
            return dice;
        }

        public void HandleFirstRound()
        {
            if (dice.Contains(6))
            {
                player.MoveToPosition(53);
            }
            else
            {
                player.MoveToPosition(26);
            }
        }
    }
}