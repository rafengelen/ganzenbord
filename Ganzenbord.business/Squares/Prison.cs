namespace Ganzenbord.Business.Squares
{
    public class Prison : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            player.TurnsToSkip(3);
        }
    }
}