using Ganzenbord.Business.Squares;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord.Business
{
    public class Player
    {
        static Random random = new Random();
        public int Position { get; private set; }
        public int Turn { get; private set; }
        public int AmountOfSkips {  get; private set; } = 0;
        public bool KeepSkipping { get; private set; } = false;
        public Game Game { get; internal set; }
        internal void StartTurn()
        {
            if (KeepSkipping) { 
                SkipTurn();
            }
            else if (AmountOfSkips > 0){
                AmountOfSkips--;
                SkipTurn();
            } else {
                int[] dice = RollDice(2);
                Move(dice);
            }
        }
        internal int[] RollDice(int amountOfDice)
        {
            int[] dice = [];
            for (int i = 0; i < amountOfDice; i++)
            {
                dice.Append(random.Next(1, 7));
            }
            return dice;
        }
        public void Move(int[] dice)
        {
            int position = Position + dice.Sum();
            if (position > 63)
            {
                Position = 126-position;
            } else {
                Position = position;
            }
            
            GetSquare(Position);

            Turn++;
        }

        public void MoveToPosition(int position)
        {
            
            Position = position;

            GetSquare(position);
        }

        private void GetSquare(int position)
        {
            if (position == 6)
            {
                ISquare square = new Bridge();
                square.PlayerEntersSquare(this);
            } else if (position == 19)
            {
                ISquare square = new Inn();
                square.PlayerEntersSquare(this);
            }
            else if (position == 31)
            {
                /*ISquare square = new Well();
                square.PlayerEntersSquare(this);*/
            }
            else if (position == 42)
            {
                ISquare square = new Maze();
                square.PlayerEntersSquare(this);
            }
            else if (position == 52)
            {
                ISquare square = new Prison();
                square.PlayerEntersSquare(this);
            }
            else if (position == 58)
            {
                ISquare square = new Death();
                square.PlayerEntersSquare(this);
            }
            else if (position == 63)
            {
                ISquare square = new End();
                square.PlayerEntersSquare(this);
            }
        }

        internal void TurnsToSkip(int amountOfSkips)
        {
            AmountOfSkips = amountOfSkips;
            //Voor nu nog Turn++, wanneer er meerdere spelers zijn -> 
        }

        internal void SkipTurn()
        {
            //To implement - log?
        }

    }
}
