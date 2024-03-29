﻿using Ganzenbord.Business.Logger;

namespace Ganzenbord.Business.Player
{
    public interface IPlayer
    {
        ILogger Logger { get; }
        int AmountOfSkips { get; set; }
        PlayerColor Color { get; }
        bool IsWinner { get; set; }
        bool KeepSkipping { get; set; }
        int[] LastDiceRole { get; set; }

        int Position { get; }
        bool ReverseMoving { get; set; }

        void Move(int[] dice);

        void MoveToPosition(int position);

        void StartTurn(int[] dice);

        void TurnsToSkip(int amountOfSkips);
    }
}