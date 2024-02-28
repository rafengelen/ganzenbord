using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Factory
{
    internal class SquareFactory
    {
        public ISquare Create(SquareType squareType)
        {
            ISquare square = null;

            switch (squareType)
            {
                case SquareType.Static:
                    square = new Static();
                    break;

                case SquareType.Maze:
                    square = new Maze();
                    break;

                case SquareType.End:
                    square = new End();
                    break;

                case SquareType.Inn:
                    square = new Inn();
                    break;

                case SquareType.Death:
                    square = new Death();
                    break;

                case SquareType.Prison:
                    square = new Prison();
                    break;

                case SquareType.Well:
                    square = new Well();
                    break;

                case SquareType.Bridge:
                    square = new Bridge();
                    break;
            }
            /*

            if (position == 6)
            {
                square = new Bridge();
            }
            else if (position == 19)
            {
                square = new Inn();
            }
            else if (position == 31)
            {
                square = new Well();
            }
            else if (position == 42)
            {
                square = new Maze();
            }
            else if (position == 52)
            {
                square = new Prison();
            }
            else if (position == 58)
            {
                square = new Death();
            }
            else if (position == 63)
            {
                square = new End();
            }
            else
            {
                square = new Static();
            }*/
            return square;
        }
    }
}