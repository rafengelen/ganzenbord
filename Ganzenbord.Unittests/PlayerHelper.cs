using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Player;
using Ganzenbord.Business;
using Moq;
using Ganzenbord.Business.Logger;

namespace Ganzenbord.Unittests
{
    internal class PlayerHelper
    {
        public static IPlayer GenerateTestPlayer(int startPosition)
        {
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            IGooseGameBoard board = new GooseGameBoard(new SquareFactory()); // Dit is GEEN goede oplossing
            IPlayerFactory playerFactory = new PlayerFactory(mockLogger.Object, board);
            IPlayer player = playerFactory.Create(PlayerColor.Red);
            player.MoveToPosition(startPosition);
            return player;
        }
    }
}
