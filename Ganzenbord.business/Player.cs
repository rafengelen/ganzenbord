using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business
{
    public class Player
    {
        private static Random random = new Random();
        public int Position { get; private set; }
        public int AmountOfSkips { get; private set; } = 0;
        public bool KeepSkipping { get; set; } = false;

        private SquareFactory squareFactory;

        public Player()
        {
            squareFactory = new SquareFactory();
        }

        public void StartTurn()
        {
            if (KeepSkipping)
            {
                SkipTurn();
            }
            else if (AmountOfSkips > 0)
            {
                AmountOfSkips--;
                SkipTurn();
            }
            else
            {
                int[] dice = RollDice(2);
                Move(dice);
            }
        }

        public int[] RollDice(int amountOfDice)
        {
            int[] dice = new int[amountOfDice];
            for (int i = 0; i < amountOfDice; i++)
            {
                dice[i] = random.Next(1, 7);
            }
            return dice;
        }

        public void Move(int[] dice)
        {
            int position = 0;
            if (Game.Instance.Turn==1 && dice.Sum()==9 && dice.Length==2) { 
                if (dice.Contains(6))
                {
                    position = 53;
                } else 
                {
                    position = 26;
                }
            } else
            {
                position = Position + dice.Sum();
            }
            
            if (position > 63)
            {
                Position = 126 - position;
            }
            else
            {
                Position = position;
            }

            GetSquare(Position);
        }

        public void MoveToPosition(int position)
        {
            Position = position;
            GetSquare(position);
        }

        private void GetSquare(int position)
        {
            //ISquare square = GameBoard.GetSquare(position);
            //ISquare square = squareFactory.Create(type);
            //square.PlayerEntersSquare(this);
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