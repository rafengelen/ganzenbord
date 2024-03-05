using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public class End : ISquare
    {
        public int Position { get; set; }

        public End(int position)
        {
            Position = position;
        }

        public void PlayerEntersSquare(IPlayer player)
        {
            player.IsWinner = true;
        }
    }
}