using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Player
{
    public class RegularPlayer(ILogger logger, IGooseGameBoard gameBoard, PlayerColor color) : IPlayer
    {
        public ILogger Logger { get; private set; } = logger;

        private IGooseGameBoard _gameBoard = gameBoard;

        public int Position { get; private set; }
        public int AmountOfSkips { get; set; } = 0;
        public bool KeepSkipping { get; set; } = false;
        public PlayerColor Color { get; private set; } = color;

        public bool IsWinner { get; set; }
        public bool ReverseMoving { get; set; } = false;
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
                Move(dice);
                ReverseMoving = false;
            }
        }

        public void Move(int[] dice)
        {
            LastDiceRole = dice;
            Position = CalculatePosition(dice);

            Logger.Log($"{Color} lands on position {Position}");
            HandleSquare(Position);
        }

        private int CalculatePosition(int[] dice)
        {
            int position;

            position = Position + dice.Sum();

            if (ReverseMoving)
            {
                return Position - dice.Sum();
            }
            else if (position > _gameBoard.Squares.Length - 1)
            {
                //Gameboard.count
                //terugkijken naar hoeveel te veel, dynamisch
                ReverseMoving = true;
                return (_gameBoard.Squares.Length - 1) * 2 - position;
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
            ISquare square = _gameBoard.GetSquare(position);
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