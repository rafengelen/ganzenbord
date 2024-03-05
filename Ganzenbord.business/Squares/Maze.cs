using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public class Maze : ISquare
    {
        public int Position { get; set; }

        public Maze(int position)
        {
            Position = position;
        }

        public void PlayerEntersSquare(IPlayer player)
        {
            player.MoveToPosition(39);
        }
    }
}