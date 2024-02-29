using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Factory
{
    public class SquareFactory
    {
        //zo min mogelijk static -> gaat tegen OO en dependancy injection in
        public ISquare Create(SquareType squareType, int position)
        {
            switch (squareType)
            {
                case SquareType.Static:
                    return new Static(position);

                case SquareType.Maze:
                    return new Maze(position);

                case SquareType.End:
                    return new End(position);

                case SquareType.Inn:
                    return new Inn(position);

                case SquareType.Death:
                    return new Death(position);

                case SquareType.Prison:
                    return new Prison(position);

                case SquareType.Well:
                    return new Well(position);

                case SquareType.Bridge:
                    return new Bridge(position);

                default:
                    return new Static(position);
            }
        }
    }
}