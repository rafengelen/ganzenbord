using Ganzenbord.Business.Factory;
using Ganzenbord.Business.GameBoard;

namespace Ganzenbord.Business
{
    public class Game
    {
        private static Game _Instance;
        public bool ActiveGame { get; set; } = false;
        public int Turn { get; set; } = 1;

        //public Player[] Players { get; set; }
        //
        public IGameBoard GameBoard { get; set; }

        private Game()
        {
            StartGame();
        }

        public static Game Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Game();
                }
                return _Instance;
            }
        }

        /*public void StopGame()
        {
            ActiveGame = false;
            //GameBoard = GameBoardFactory.Create(GameBoardType.GooseGame);
        }*/

        public void StartGame()
        {
            //in constructor
            Turn = 1;
            GameBoard = GameBoardFactory.Create(GameBoardType.GooseGame);
            ActiveGame = true;
        }
    }
}