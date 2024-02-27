using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord.Business
{
    public class Game
    {
        private static Game _Instance;
        private Game() { }
        public static Game Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new Game();
                }
                return _Instance;
            }
        }
        public int Turn { get; private set; } = 1;
        
        public void PlayRound(List<Player> players)
        {
            foreach (Player player in players)
            {
                player.StartTurn();
            }
            Turn++;
        }

    }
}
