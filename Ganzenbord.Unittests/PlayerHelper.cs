using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Player;
using Ganzenbord.Business;
using Moq;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Dice;

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

        public static Game GenerateGame(int []dice)
        {
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            Mock<IDiceGenerator> diceGenerator = new Mock<IDiceGenerator>();
            Mock<IPlayerFactory> playerFactory = new Mock<IPlayerFactory>();

            diceGenerator.Setup(generator => generator.RollDice(It.IsAny<int>())).Returns(dice);

            return new Game(mockLogger.Object, diceGenerator.Object, playerFactory.Object);
        }
    }
}
