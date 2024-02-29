using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.GameBoard
{
    public class GooseGameBoard : IGameBoard
    {
        public ISquare[] Squares { get; set; }
        private SquareFactory squareFactory;

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

        public GooseGameBoard(SquareFactory factory)
        {
            squareFactory = factory;
            SetupGameBoard();
        }

        internal void SetupGameBoard()
        {
            ISquare[] squares = new ISquare[64];
            //andere manier if specialSquares.contains(i)
            for (int i = 0; i < 64; i++)
            {
                squares[i] = AddSquare(i);
            }
            Squares = squares;
        }

        public ISquare GetSquare(int position)
        {
            return Squares.Single(item => item.Position == position);
        }

        private ISquare AddSquare(int position)
        {
            if (SpecialSquares.TryGetValue(position, out SquareType value))
            {
                return squareFactory.Create(value, position);
            }
            else
            {
                return squareFactory.Create(SquareType.Static, position);
            }
        }
    }
}