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
        private SquareFactory squareFactory;
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
        public GameBoard() { 
            squareFactory = new SquareFactory();
        }
        public void SetupGameBoard()
        {
            ISquare[] squares = new ISquare[64];

            for (int i = 0; i < 64 ; i++)
            {
                SquareType type = SquareType.Static;
                if (specialSquares.TryGetValue(i, out SquareType value)){
                    type = value;
                }
             
                squares[i]= squareFactory.Create(type);
            }
            Squares = squares;
        }
        public ISquare GetSquare(int position)
        {
            return Squares[position];
        }
    }
}
