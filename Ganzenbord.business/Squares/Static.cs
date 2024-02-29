using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public class Static : ISquare
    {
        public Static(int position)
        {
            Position = position;
        }

        public int Position { get; set; }

        public void PlayerEntersSquare(IPlayer player)
        {
            //Log?
        }
    }
}