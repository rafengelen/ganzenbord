using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public class End : ISquare
    {
        public End(int position)
        {
            Position = position;
        }

        public int Position { get; set; }

        public void PlayerEntersSquare(IPlayer player)
        {
            player.IsWinner = true;
        }
    }
}