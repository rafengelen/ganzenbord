using Ganzenbord.Business.Dice;
using Ganzenbord.Business;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;
using Ganzenbord.Business.Squares;
using Moq;

namespace Ganzenbord.Unittests
{
    public class SquareTests
    {
        [Fact]
        public void WhenPlayerLandsOnBridge_ThenPutPlayerOnSquare12()
        {
            //arrange
            Bridge bridge = new Bridge(6);
            Mock<ILogger> logger = new Mock<ILogger>();
            RegularPlayer player = new RegularPlayer(logger.Object, PlayerColor.Red);

            //act
            bridge.PlayerEntersSquare(player);

            //assert
            Assert.Equal(12, player.Position);
        }

        [Fact]
        public void WhenPlayerLandsOnInn_ThenSkipNextTurn()
        {
            //arrange
            Inn inn = new Inn(19);
            Mock<ILogger> logger = new Mock<ILogger>();
            RegularPlayer player = new RegularPlayer(logger.Object, PlayerColor.Red);

            //act
            inn.PlayerEntersSquare(player);

            //assert
            Assert.Equal(1, player.AmountOfSkips);
        }

        [Fact]
        public void WhenPlayerLandsOnInnAndSkipsTurn_ThenStaysOnPositionAndLowersSkipsAmount()
        {
            //arrange
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            Mock<IDiceGenerator> diceGenerator = new Mock<IDiceGenerator>();
            IPlayer player = new RegularPlayer(mockLogger.Object, PlayerColor.Red);
            Game game = new Game(mockLogger.Object, diceGenerator.Object, PlayerType.Regular, 2, 1);
            game.Players = [player];
            player.AmountOfSkips = 1;

            //act
            game.PlayRound();

            //assert
            Assert.Equal(0, player.AmountOfSkips);
       
        }

        [Fact]
        public void WhenPlayerLandsOnWell_ThenSkipUntilAnotherPlayerArrives()
        {
            //ARRANGE

            Mock<ILogger> logger = new Mock<ILogger>();
            RegularPlayer player1 = new RegularPlayer(logger.Object, PlayerColor.Red);
            RegularPlayer player2 = new RegularPlayer(logger.Object, PlayerColor.Blue);

            Well well = new Well(31);

            //ACT
            well.PlayerEntersSquare(player1);

            //ASSERT
            Assert.Equal(player1, well.SkippedPlayer);
            Assert.True(player1.KeepSkipping);

            //ACT
            well.PlayerEntersSquare(player2);

            //ASSERT
            Assert.Equal(player2, well.SkippedPlayer);
            Assert.False(player1.KeepSkipping);
            Assert.True(player2.KeepSkipping);
        }

        [Fact]
        public void WhenPlayerLandsOnMaze_ThenPutPlayerOnSquare39()
        {
            //arrange
            Mock<ILogger> logger = new Mock<ILogger>();
            RegularPlayer player = new RegularPlayer(logger.Object, PlayerColor.Red);
            Maze maze = new Maze(42);

            //act
            maze.PlayerEntersSquare(player);

            //assert
            Assert.Equal(39, player.Position);
        }

        [Fact]
        public void WhenPlayerLandsOnPrison_ThenSkip3Turns()
        {
            //arrange
            Mock<ILogger> logger = new Mock<ILogger>();
            RegularPlayer player = new RegularPlayer(logger.Object, PlayerColor.Red);
            Prison prison = new Prison(52);

            //act
            prison.PlayerEntersSquare(player);

            //assert
            Assert.Equal(3, player.AmountOfSkips);
        }

        [Fact]
        public void WhenPlayerLandsOnDeath_ThenPutPlayerAtStart()
        {
            //arrange
            Mock<ILogger> logger = new Mock<ILogger>();
            RegularPlayer player = new RegularPlayer(logger.Object, PlayerColor.Red);
            Death death = new Death(58);

            //act
            death.PlayerEntersSquare(player);

            //assert
            Assert.Equal(0, player.Position);
        }

        [Fact]
        public void WhenPlayerLandsOnEnd_ThenEndGame()
        {
            //arrange
            Mock<ILogger> logger = new Mock<ILogger>();
            RegularPlayer player = new RegularPlayer(logger.Object, PlayerColor.Red);
            End end = new End(63);

            //act
            end.PlayerEntersSquare(player);

            //assert
            Assert.True(player.IsWinner);
        }
    }
}