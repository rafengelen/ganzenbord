using Ganzenbord.Business;
using Ganzenbord.Business.Dice;
using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;
using Moq;

namespace Ganzenbord.Unittests
{
    public class PlayerMovementTests
    {
        [Fact]
        public void WhenPlayerRollsDice_ThenPlayerMoves()
        {
            //ARRANGE
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            Mock<IDiceGenerator> diceGenerator = new Mock<IDiceGenerator>();
            Mock<IPlayerFactory> playerFactory = new Mock<IPlayerFactory>();

            IPlayer player = new RegularPlayer(mockLogger.Object, PlayerColor.Red);
            Game game = new Game(mockLogger.Object, diceGenerator.Object, playerFactory.Object, PlayerType.Regular);
            game.Players = [player];
            player.MoveToPosition(1);
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

            //assert
            Assert.Equal(4, player.Position);
        }

        [Fact]
        public void WhenPlayerRollsDiceAndNotSkipping_ThenNotStandingStill()
        {
            //ARRANGE
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            Mock<IDiceGenerator> diceGenerator = new Mock<IDiceGenerator>();
            Mock<IPlayerFactory> playerFactory = new Mock<IPlayerFactory>();

            IPlayer player = new RegularPlayer(mockLogger.Object, PlayerColor.Red);
            Game game = new Game(mockLogger.Object, diceGenerator.Object, playerFactory.Object, PlayerType.Regular);
            game.Players = [player];
            player.MoveToPosition(1);
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

            //assert
            Assert.NotEqual(1, player.Position);
        }

        [Fact]
        public void WhenPlayerMovesFurtherThan63_ThenPlayerWalksRemainingStepsBackwards()
        {
            //ARRANGE
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            Mock<IDiceGenerator> diceGenerator = new Mock<IDiceGenerator>();
            Mock<IPlayerFactory> playerFactory = new Mock<IPlayerFactory>();

            IPlayer player = new RegularPlayer(mockLogger.Object, PlayerColor.Red);
            Game game = new Game(mockLogger.Object, diceGenerator.Object, playerFactory.Object, PlayerType.Regular);
            game.Players = [player];
            player.MoveToPosition(62);
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

            //assert
            Assert.Equal(61, player.Position);
        }

        [Theory]
        [InlineData(new int[] { 5, 4 }, 0, 26, 1)]
        [InlineData(new int[] { 4, 5 }, 0, 26, 1)]
        public void WhenPlayerRolls5And4InTurn1_ThenGoTo26(int[] dice, int startPosition, int endPosition, int round)
        {
            //ARRANGE
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            Mock<IDiceGenerator> diceGenerator = new Mock<IDiceGenerator>();
            Mock<IPlayerFactory> playerFactory = new Mock<IPlayerFactory>();
            diceGenerator.Setup(generator => generator.RollDice(It.IsAny<int>())).Returns(dice);

            IPlayer player = new RegularPlayer(mockLogger.Object, PlayerColor.Red);
            Game game = new Game(mockLogger.Object, diceGenerator.Object, playerFactory.Object, PlayerType.Regular);
            game.Players = [player];
            player.MoveToPosition(startPosition);
            game.Turn = round;

            //ACT
            game.PlayRound();

            //ASSERT
            Assert.Equal(endPosition, player.Position);
        }

        [Theory]
        [InlineData(new int[] { 3, 6 }, 0, 53, 1)]
        [InlineData(new int[] { 6, 3 }, 0, 53, 1)]
        public void WhenPlayerRolls3And5InTurn1_ThenGoTo52(int[] dice, int startPosition, int endPosition, int round)
        {
            //ARRANGE
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            Mock<IDiceGenerator> diceGenerator = new Mock<IDiceGenerator>();
            Mock<IPlayerFactory> playerFactory = new Mock<IPlayerFactory>();
            diceGenerator.Setup(generator => generator.RollDice(It.IsAny<int>())).Returns(dice);

            IPlayer player = new RegularPlayer(mockLogger.Object, PlayerColor.Red);
            Game game = new Game(mockLogger.Object, diceGenerator.Object, playerFactory.Object, PlayerType.Regular);
            game.Players = [player];
            player.MoveToPosition(startPosition);
            game.Turn = round;

            //ACT
            game.PlayRound();

            //ASSERT
            Assert.Equal(endPosition, player.Position);
        }

        [Theory]
        [InlineData(new int[] { 5, 4 }, 0, 26, 2)]
        [InlineData(new int[] { 5, 4 }, 0, 26, 3)]
        [InlineData(new int[] { 4, 5 }, 0, 26, 2)]
        [InlineData(new int[] { 4, 5 }, 0, 26, 3)]
        public void WhenPlayerRolls5And4NotInTurn1_ThenNotGoTo26(int[] dice, int startPosition, int endPosition, int round)
        {
            //ARRANGE
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            Mock<IDiceGenerator> diceGenerator = new Mock<IDiceGenerator>();
            Mock<IPlayerFactory> playerFactory = new Mock<IPlayerFactory>();
            diceGenerator.Setup(generator => generator.RollDice(It.IsAny<int>())).Returns(dice);

            IPlayer player = new RegularPlayer(mockLogger.Object, PlayerColor.Red);
            Game game = new Game(mockLogger.Object, diceGenerator.Object, playerFactory.Object, PlayerType.Regular);
            game.Players = [player];
            player.MoveToPosition(startPosition);
            game.Turn = round;

            //ACT
            game.PlayRound();

            //ASSERT
            Assert.NotEqual(endPosition, player.Position);
        }

        [Theory]
        [InlineData(new int[] { 6, 3 }, 0, 52, 2)]
        [InlineData(new int[] { 6, 3 }, 0, 52, 3)]
        [InlineData(new int[] { 3, 6 }, 0, 52, 2)]
        [InlineData(new int[] { 3, 6 }, 0, 52, 3)]
        public void WhenPlayerRolls3And6NotInTurn1_ThenNotGoTo52(int[] dice, int startPosition, int endPosition, int round)
        {
            //ARRANGE
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            Mock<IDiceGenerator> diceGenerator = new Mock<IDiceGenerator>();
            Mock<IPlayerFactory> playerFactory = new Mock<IPlayerFactory>();

            diceGenerator.Setup(generator => generator.RollDice(It.IsAny<int>())).Returns(dice);

            IPlayer player = new RegularPlayer(mockLogger.Object, PlayerColor.Red);
            Game game = new Game(mockLogger.Object, diceGenerator.Object, playerFactory.Object, PlayerType.Regular);
            game.Players = [player];
            player.MoveToPosition(startPosition);
            game.Turn = round;

            //ACT
            game.PlayRound();

            //ASSERT
            Assert.NotEqual(endPosition, player.Position);
        }
    }
}