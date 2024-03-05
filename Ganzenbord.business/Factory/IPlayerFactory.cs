using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Factory
{
    public interface IPlayerFactory
    {
        IPlayer Create(PlayerColor color);
    }
}