using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public class Well : ISquare
    {
        public Well(int position)
        {
            Position = position;
        }

        public int Position { get; set; }
        public IPlayer? SkippedPlayer { get; set; }

        public void PlayerEntersSquare(IPlayer player)
        {
            if (SkippedPlayer != null)
            {
                SkippedPlayer.KeepSkipping = false;
            }
            player.KeepSkipping = true;
            SkippedPlayer = player;
            //Game.Instance.GameBoard.Squares[31] = this;
        }
    }
}