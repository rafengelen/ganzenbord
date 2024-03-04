using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Factory
{
    public interface IPlayerFactory
    {
        IPlayer Create(ILogger logger, PlayerType type, PlayerColor color);
    }
}