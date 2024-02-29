using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Player
{
    public class Player(PlayerColor color, ILogger logger) : IPlayer
    {
        private static Random random = new Random();
        public int Position { get; private set; }
        public int AmountOfSkips { get; set; } = 0;
        public bool KeepSkipping { get; set; } = false;
        public PlayerColor Color { get; private set; } = color;
        public ILogger Logger { get; private set; } = logger;
        public bool IsWinner { get; set; }

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
            Logger.Log($"{Color} rolls {string.Join(", ", dice)}");
            return dice;
        }

        public void Move(int[] dice)
        {
            Position = CalculatePosition(dice);

            Logger.Log($"{Color} lands on position {Position}");
            HandleSquare(Position);
        }

        private int CalculatePosition(int[] dice)
        {
            int position;
            //TODO turn1 moet in game klasse komen
            if (Game.Instance.Turn == 1 && dice.Sum() == 9 && dice.Length == 2)
            {
                if (dice.Contains(6))
                {
                    position = 53;
                }
                else
                {
                    position = 26;
                }
            }
            else
            {
                position = Position + dice.Sum();
            }

            if (position > 63)
            {
                //Gameboard.count
                //terugkijken naar hoeveel te veel, dynamisch
                return 126 - position;
            }
            else
            {
                return position;
            }
        }

        public void MoveToPosition(int position)
        {
            Position = position;
        }

        private void HandleSquare(int position)
        {
            ISquare square = Game.Instance.GameBoard.GetSquare(position);
            Logger.Log($"{Color} current square: {square.GetType().Name}");
            square.PlayerEntersSquare(this);
        }

        public void TurnsToSkip(int amountOfSkips)
        {
            AmountOfSkips = amountOfSkips;
        }

        internal void SkipTurn()
        {
            Logger.Log($"{Color} Skips turn");
        }
    }
}