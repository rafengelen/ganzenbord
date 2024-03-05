using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public class Prison : ISquare
    {
        public int Position { get; set; }

        public Prison(int position)
        {
            Position = position;
        }

        public void PlayerEntersSquare(IPlayer player)
        {
            player.TurnsToSkip(3);
        }
    }
}