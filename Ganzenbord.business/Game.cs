

namespace Ganzenbord.Business
{
    public class Game
    {
        private static Game _Instance;
        public bool ActiveGame { get; private set; } = false;
        public int Turn { get; set; } = 1;
        public Player[] Players { get; set; }
        public GameBoard GameBoard { get; set; }
        private Game()
        { }

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

        public void PlayRound(Player[] players)
        {
            foreach (Player player in players)
            {
                player.StartTurn();
            }
            Turn++;
        }

        public void StopGame()
        {
            ActiveGame = false;
        }

        public void StartGame()
        {
            Turn = 1;
            GameBoard = new GameBoard();
            ActiveGame = true;
        }
    }
}