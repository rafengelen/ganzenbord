using Ganzenbord.Business;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Squares;

namespace Ganzenbord.Unittests
{
    public class SquareTests
    {
        [Fact]
        public void WhenPlayerLandsOnBridge_ThenPutPlayerOnSquare12()
        {
            //arrange
            Bridge bridge = new Bridge();
            Player player = new Player(PlayerColor.Red, new ConsoleLogger());
            
            //act
            bridge.PlayerEntersSquare(player);

            //assert
            Assert.Equal(12, player.Position);
        }

        [Fact]
        public void WhenPlayerLandsOnInn_ThenSkipNextTurn()
        {
            //arrange
            Inn inn = new Inn();
            Player player = new Player(PlayerColor.Red, new ConsoleLogger());

            //act
            inn.PlayerEntersSquare(player);

            //assert
            Assert.Equal(1, player.AmountOfSkips);
        }

        [Fact]
        public void WhenPlayerLandsOnInnAndSkipsTurn_ThenStaysOnPositionAndLowersSkipsAmount()
        {
            //arrange
            Player player = new Player(PlayerColor.Red, new ConsoleLogger());
            player.AmountOfSkips = 1;

            //act
            player.StartTurn();

            //assert
            Assert.Equal(0, player.AmountOfSkips);
        }

        [Fact]
        public void WhenPlayerLandsOnWell_ThenSkipUntilAnotherPlayerArrives()
        {
            //ARRANGE

            Player player1 = new Player(PlayerColor.Red, new ConsoleLogger());
            Player player2 = new Player(PlayerColor.Blue, new ConsoleLogger());

            Well well = new Well();

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
            Player player = new Player(PlayerColor.Red, new ConsoleLogger());
            Maze maze = new Maze();

            //act
            maze.PlayerEntersSquare(player);

            //assert
            Assert.Equal(39, player.Position);
        }
        [Fact]
        public void WhenPlayerLandsOnPrison_ThenSkip3Turns()
        {
            //arrange
            Player player = new Player(PlayerColor.Red, new ConsoleLogger());
            Prison prison = new Prison();

            //act
            prison.PlayerEntersSquare(player);

            //assert
            Assert.Equal(3, player.AmountOfSkips);
        }
        
        [Fact]
        public void WhenPlayerLandsOnDeath_ThenPutPlayerAtStart()
        {
            //arrange
            Player player = new Player(PlayerColor.Red, new ConsoleLogger());
            Death death = new Death();

            //act
            death.PlayerEntersSquare(player);

            //assert
            Assert.Equal(0, player.Position);
        }

        [Fact]
        public void WhenPlayerLandsOnEnd_ThenEndGame()
        {
            //arrange
            Game.Instance.StartGame();
            

            Player player = new Player(PlayerColor.Red, new ConsoleLogger());
            End end = new End();

            //act
            end.PlayerEntersSquare(player);

            //assert
            Assert.False(Game.Instance.ActiveGame);
        }
    }
}