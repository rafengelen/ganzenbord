using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Factory
{
    public class SquareFactory : ISquareFactory
    {
        public ISquare Create(SquareType squareType, int position)
        {
            switch (squareType)
            {
                case SquareType.Regular:
                    return new Regular(position);

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

                case SquareType.Goose:
                    return new Goose(position);
                default:
                    throw new Exception($"Cannot create square with type {squareType}");
            }
        }
    }
}