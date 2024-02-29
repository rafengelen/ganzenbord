using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.GameBoard
{
    public interface IGameBoard
    {
        ISquare GetSquare(int position);
    }
}