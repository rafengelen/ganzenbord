using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public class Prison : ISquare
    {
        public Prison(int position)
        {
            Position = position;
        }

        public int Position { get; set; }

        public void PlayerEntersSquare(IPlayer player)
        {
            player.TurnsToSkip(3);
        }
    }
}