using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Factory
{
    public interface ISquareFactory
    {
        ISquare Create(SquareType squareType, int position);
    }
}