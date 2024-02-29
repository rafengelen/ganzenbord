using Ganzenbord.Business.Factory;
using Ganzenbord.Business.GameBoard;
using Ganzenbord.Business.Logger;

namespace Ganzenbord.Business
{
    public class Game
    {
        private static Game _Instance;
        public bool ActiveGame { get; private set; } = false;
        public int Turn { get; set; } = 1;
        public Player[] Players { get; set; }
        public IGameBoard GameBoard { get; set; }
        private ILogger logger;

        private Game(ConsoleLogger logger)
        {
            this.logger = logger;
        }

        public static Game Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Game(new ConsoleLogger());
                }
                return _Instance;
            }
        }

        

        public void StopGame()
        {
            ActiveGame = false;
        }

        public void StartGame(GameBoardType type)
        {
            Turn = 1;
            GameBoard = GameBoardFactory.Create(type);
            ActiveGame = true;
        }
    }
}