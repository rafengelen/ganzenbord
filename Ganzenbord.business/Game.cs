using Ganzenbord.Business.Dice;
using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;

namespace Ganzenbord.Business
{
    public class Game
    {
        public IDiceGenerator diceGenerator;
        public IPlayerFactory playerFactory;
        private ILogger logger;
        private Random random = new Random();
        public int Turn { get; set; } = 1;
        public bool ActiveGame { get; set; } = false;
        private int AmountOfDice { get; set; }
        public bool IsValidGame { get; set; }

        public IPlayer[] Players { get; set; }

        public Game(ILogger logger, IDiceGenerator diceGenerator, IPlayerFactory playerFactory, PlayerType playerType, int amountOfDice = 2, int amountOfPlayers = 4)
        {
            this.logger = logger;
            this.diceGenerator = diceGenerator;
            this.playerFactory = playerFactory;

            AmountOfDice = amountOfDice;
            IsValidGame = ValidPlayers(amountOfPlayers);
            if (IsValidGame)
            {
                Players = CreatePlayers(logger, amountOfPlayers, playerType);
            }
        }

        private IPlayer[] CreatePlayers(ILogger logger, int amountOfPlayers, PlayerType playerType)
        {
            IPlayer[] players = new IPlayer[amountOfPlayers];

            for (int i = 0; i < amountOfPlayers; i++)
            {
                PlayerColor color = (PlayerColor)i;
                IPlayer player = playerFactory.Create(logger, playerType, color);
                players[i] = player;
            }

            return players;
        }

        public bool ValidPlayers(int amountOfPlayers)
        {
            if (amountOfPlayers > 4)
            {
                logger.Log($"{amountOfPlayers} are too many players, this game can be played with max 4 players.");
                return false;
            }
            else if (amountOfPlayers < 1)
            {
                logger.Log($"Cannot play Goose Game with less than 1 player. {amountOfPlayers} is an invalid amount.");
                return false;
            }
            return true;
        }

        public void StartGame()
        {
            if (IsValidGame)
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

                int[] dice = diceGenerator.RollDice(AmountOfDice);
                if (!player.KeepSkipping && player.AmountOfSkips == 0)
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
                logger.WaitForKeyStroke();
            }
            if (ActiveGame)
            {
                Turn++;
            }
        }

        public void HandleFirstRound(IPlayer player, int[] dice)
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