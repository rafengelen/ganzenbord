using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.GameBoard
{
    public class GooseGameBoard : IGameBoard
    {
        public ISquare[] Squares { get; set; }

        private readonly Dictionary<int, SquareType> SpecialSquares = new Dictionary<int, SquareType>
            {
                { 6, SquareType.Bridge },
                { 19, SquareType.Inn },
                { 31, SquareType.Well },
                { 42, SquareType.Maze },
                { 52, SquareType.Prison },
                { 58, SquareType.Death },
                { 63, SquareType.End }
            };

        public GooseGameBoard()
        {
            SetupGameBoard();
        }

        internal void SetupGameBoard()
        {
            ISquare[] squares = new ISquare[64];

            for (int i = 0; i < 64; i++)
            {
                squares[i] = AddSquare(i);
            }
            Squares = squares;
        }

        public ISquare GetSquare(int position)
        {
            return Squares[position];
        }

        private ISquare AddSquare(int position)
        {
            if (SpecialSquares.TryGetValue(position, out SquareType value))
            {
                return SquareFactory.Create(value);
            }
            else
            {
                return SquareFactory.Create(SquareType.Static);
            }
        }
    }
}