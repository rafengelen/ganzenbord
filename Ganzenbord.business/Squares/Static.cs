using Ganzenbord.Business.Logger;

namespace Ganzenbord.Business.Squares
{
    public class Static : ISquare
    {
        public int Position { get; set; }

        public void PlayerEntersSquare(Player player)
        {
            //Log?
        }
    }
}