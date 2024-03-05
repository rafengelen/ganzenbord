using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;

namespace Ganzenbord.Business.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        private ILogger _logger;
        private IGooseGameBoard _gooseGameBoard;

        public PlayerFactory(ILogger logger, IGooseGameBoard gooseGameBoard)
        {
            _logger = logger;
            _gooseGameBoard = gooseGameBoard;
        }

        public IPlayer Create(PlayerColor color)
        {
            return new RegularPlayer(_logger, _gooseGameBoard, color);

        }
    }
}