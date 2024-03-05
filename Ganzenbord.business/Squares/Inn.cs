using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public class Inn : ISquare
    {
        public int Position { get; set; }

        public Inn(int position)
        {
            Position = position;
        }

        public void PlayerEntersSquare(IPlayer player)
        {
            player.TurnsToSkip(1);
        }
    }
}