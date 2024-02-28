namespace Ganzenbord.Business.Squares
{
    public class Maze : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            player.MoveToPosition(39);
        }
    }
}