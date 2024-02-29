namespace Ganzenbord.Business.Squares
{
    public class Well : ISquare
    {
        public int Position { get; set; }
        public Player SkippedPlayer { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            if (SkippedPlayer != null)
            {
                SkippedPlayer.KeepSkipping = false;
            }
            player.KeepSkipping = true;
            SkippedPlayer = player;
        }
    }
}