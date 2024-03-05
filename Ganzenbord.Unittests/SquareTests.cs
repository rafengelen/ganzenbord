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
            IPlayer player = PlayerHelper.GenerateTestPlayer(1);

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
            IPlayer player = PlayerHelper.GenerateTestPlayer(1);

            //act
            inn.PlayerEntersSquare(player);

            //assert
            Assert.Equal(1, player.AmountOfSkips);
        }

        [Fact]
        public void WhenPlayerLandsOnWell_ThenSkipUntilAnotherPlayerArrives()
        {
            //ARRANGE

            Mock<ILogger> logger = new Mock<ILogger>();
            IPlayer player1 = PlayerHelper.GenerateTestPlayer(1);
            IPlayer player2 = PlayerHelper.GenerateTestPlayer(1);

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
            IPlayer player = PlayerHelper.GenerateTestPlayer(1);
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
            IPlayer player = PlayerHelper.GenerateTestPlayer(1);
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
            IPlayer player = PlayerHelper.GenerateTestPlayer(1);
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
            IPlayer player = PlayerHelper.GenerateTestPlayer(1);
            End end = new End(63);

            //act
            end.PlayerEntersSquare(player);

            //assert
            Assert.True(player.IsWinner);
        }
    }
}