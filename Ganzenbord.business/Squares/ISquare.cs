using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public interface ISquare
    {
        int Position { get; set; }

        void PlayerEntersSquare(IPlayer player);
    }
}