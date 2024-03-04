using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public class Regular : ISquare
    {
        public Regular(int position)
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