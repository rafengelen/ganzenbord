using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.GameBoard
{
    public interface IGameBoard
    {
        ISquare[] Squares { get; set; }

        ISquare GetSquare(int position);
    }
}