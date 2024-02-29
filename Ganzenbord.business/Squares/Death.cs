﻿using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public class Death : ISquare
    {
        public int Position { get; set; }

        public Death(int position)
        {
            Position = position;
        }

        public void PlayerEntersSquare(IPlayer player)
        {
            player.MoveToPosition(0);
        }
    }
}