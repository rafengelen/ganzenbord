using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord.Business
{
    public class GameBoard
    {
        private ISquare[] Squares { get; set; }
        Dictionary<int, SquareType> specialSquares = new Dictionary<int, SquareType>
            {
                { 6, SquareType.Bridge },
                { 19, SquareType.Inn },
                { 31, SquareType.Well },
                { 42, SquareType.Maze },
                { 52, SquareType.Prison },
                { 58, SquareType.Death },
                { 63, SquareType.End }
            };
        public GameBoard()
        {
            SetupGameBoard();
        }
        internal void SetupGameBoard()
        {
            ISquare[] squares = new ISquare[64];

            for (int i = 0; i < 64; i++)
            {
                squares[i] = addSquare(i);
            }
            Squares = squares;
        }
        public ISquare GetSquare(int position)
        {
            return Squares[position];
        }
        
        private ISquare addSquare(int position)
        {
            if (specialSquares.TryGetValue(position, out SquareType value))
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
