using Ganzenbord.Business.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord.Business.Squares
{
    public class Goose : ISquare
    {
        

        public int Position { get; set; }
        public Goose(int position)
        {
            Position = position;
        }

        public void PlayerEntersSquare(IPlayer player)
        {
            player.Move(player.LastDiceRole);
        }
    }
}
