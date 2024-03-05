using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Squares
{
    public class Regular : ISquare
    {
        public int Position { get; set; }

        public Regular(int position)
        {
            Position = position;
        }

        public void PlayerEntersSquare(IPlayer player)
        {
            //Log?
        }
    }
}