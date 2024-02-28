﻿namespace Ganzenbord.Business.Squares
{
    public class Death : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            player.MoveToPosition(0);
        }
    }
}