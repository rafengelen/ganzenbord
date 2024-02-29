using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Factory
{
    public class SquareFactory
    {
        public static ISquare Create(SquareType squareType)
        {
            switch (squareType)
            {
                case SquareType.Static:
                    return new Static();

                case SquareType.Maze:
                    return new Maze();

                case SquareType.End:
                    return new End();

                case SquareType.Inn:
                    return new Inn();

                case SquareType.Death:
                    return new Death();

                case SquareType.Prison:
                    return new Prison();

                case SquareType.Well:
                    return new Well();

                case SquareType.Bridge:
                    return new Bridge();

                default:
                    return new Static();
            }
        }
    }
}