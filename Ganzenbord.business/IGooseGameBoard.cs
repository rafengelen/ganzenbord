using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business
{
    public interface IGooseGameBoard
    {
        ISquare[] Squares { get; set; }

        ISquare GetSquare(int position);
    }
}