﻿namespace Ganzenbord.Business.Squares
{
    public class Inn : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            player.TurnsToSkip(1);
        }
    }
}