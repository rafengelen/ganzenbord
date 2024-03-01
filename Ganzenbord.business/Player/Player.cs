using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Player
{
    public class Player(ILogger logger, PlayerColor color) : IPlayer
    {

        public int Position { get; private set; }
        public int AmountOfSkips { get; set; } = 0;
        public bool KeepSkipping { get; set; } = false;
        public PlayerColor Color { get; private set; } = color;
        public ILogger Logger { get; private set; } = logger;
        public bool IsWinner { get; set; }
        public int[] LastDiceRole { get; set; }

        public void StartTurn(int[] dice)
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
                LastDiceRole = dice;
                Move(dice);
            }
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
            
            
            position = Position + dice.Sum();
            

            if (position > Game.Instance.GameBoard.Squares.Length - 1)
            {
                //Gameboard.count
                //terugkijken naar hoeveel te veel, dynamisch
                return (Game.Instance.GameBoard.Squares.Length - 1) * 2 - position;
            }
            else
            {
                return position;
            }
        }

        //steps

        public void MoveToPosition(int position)
        {
            Position = position;
            HandleSquare(Position);
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