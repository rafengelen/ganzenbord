using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public class Inn : ISquare
    {
        public Inn(int position)
        {
            Position = position;
        }

        public int Position { get; set; }

        public void PlayerEntersSquare(IPlayer player)
        {
            player.TurnsToSkip(1);
        }
    }
}