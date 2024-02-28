namespace Ganzenbord.Business.Squares
{
    public class End : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            //player.Game.EndGame();
        }
    }
}