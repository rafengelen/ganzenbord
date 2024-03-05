using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public class Goose : ISquare
    {
        public int Position { get; set; }

        public Goose(int position)
        {
            Position = position;
        }

        public void PlayerEntersSquare(IPlayer player)
        {
            player.Move(player.LastDiceRole);
        }
    }
}