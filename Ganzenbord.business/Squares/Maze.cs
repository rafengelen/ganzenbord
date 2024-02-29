using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public class Maze : ISquare
    {
        public Maze(int position)
        {
            Position = position;
        }

        public int Position { get; set; }

        public void PlayerEntersSquare(IPlayer player)
        {
            player.MoveToPosition(39);
        }
    }
}