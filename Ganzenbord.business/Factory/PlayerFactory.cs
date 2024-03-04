using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer Create(ILogger logger, PlayerType type, PlayerColor color)
        {
            switch (type)
            {
                case PlayerType.Regular:
                    return new RegularPlayer(logger, color);

                default:
                    throw new Exception($"Cannot find player type {type}");
            }
        }
    }
}