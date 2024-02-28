using Ganzenbord.Business;
using Ganzenbord.Business.Squares;

namespace Ganzenbord.Unittests
{
    public class SquareTests
    {
        [Fact]
        public void WhenPlayerLandsOnBridge_ThenPutPlayerOnSquare12()
        {
            //arrange
            Game.Instance.StartGame();
            Player player = new Player();
            player.MoveToPosition(3);
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

            //assert
            Assert.Equal(12, player.Position);
        }

        [Fact]
        public void WhenPlayerLandsOnInn_ThenSkipNextTurn()
        {
            //arrange
            Game.Instance.StartGame();
            Player player = new Player();
            player.MoveToPosition(16);
            int[] dice = { 1, 2 };


            //act
            player.Move(dice);

            //assert
            Assert.Equal(1, player.AmountOfSkips);
        }
        [Fact]
        public void WhenPlayerLandsOnInnAndSkipsTurn_ThenStaysOnPositionAndLowersSkipsAmount()
        {
            //arrange
            Game.Instance.StartGame();
            Player player = new Player();
            player.MoveToPosition(16);
            int[] dice = { 1, 2 };
            player.Move(dice);

            //act
            player.StartTurn();

            //assert
            Assert.Equal(19, player.Position);
            Assert.Equal(0, player.AmountOfSkips);
        }


        [Fact]
        public void WhenPlayerLandsOnWell_ThenSkipUntilAnotherPlayerArrives()
        {
            //ARRANGE
            Game.Instance.StartGame();

            Player player1 = new Player();
            Player player2 = new Player();

            player1.MoveToPosition(28);
            player2.MoveToPosition(28);
            int[] dice = { 1, 2 };

            //ACT
            player1.Move(dice);

            //ASSERT
            Assert.True(player1.KeepSkipping);
            Well well = (Well)Game.Instance.GameBoard.GetSquare(31);
            Assert.Equal(player1, well.SkippedPlayer);

            //ACT
            player2.Move(dice);

            //ASSERT
            Assert.False(player1.KeepSkipping);
            well = (Well)Game.Instance.GameBoard.GetSquare(31);
            Assert.Equal(player2, well.SkippedPlayer);
        }

        [Fact]
        public void WhenPlayerLandsOnMaze_ThenPutPlayerOnSquare39()
        {
            //arrange
            Game.Instance.StartGame();
            Player player = new Player();
            player.MoveToPosition(38);
            int[] dice = { 1, 3 };

            //act
            player.Move(dice);

            //assert
            Assert.Equal(39, player.Position);
        }

        [Fact]
        public void WhenPlayerLandsOnPrisoAndSkipsTurn_ThenStaysOnPositionAndLowersSkipsAmount()
        {
            //arrange
            Game.Instance.StartGame();
            Player player = new Player();
            player.MoveToPosition(49);
            int[] dice = { 1, 2 };
            player.Move(dice);
            //act
            player.StartTurn();

            //assert
            Assert.Equal(52, player.Position);
            Assert.Equal(2, player.AmountOfSkips);
        }
        [Fact]
        public void WhenPlayerLandsOnPrison_ThenSkip3Turns()
        {
            //arrange
            Game.Instance.StartGame();
            Player player = new Player();
            player.MoveToPosition(49);
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

            //assert
            Assert.Equal(3, player.AmountOfSkips);
        }

        [Fact]
        public void WhenPlayerLandsOnDeath_ThenPutPlayerAtStart()
        {
            //arrange
            Game.Instance.StartGame();
            Player player = new Player();
            player.MoveToPosition(55);
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

            //assert
            Assert.Equal(0, player.Position);
        }

        [Fact]
        public void WhenPlayerLandsOnEnd_ThenEndGame()
        {
            //arrange
            Game.Instance.StartGame();
            Player player = new Player();
            //game.Players = players;
            player.MoveToPosition(60);
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

            //assert
            Assert.False(Game.Instance.ActiveGame);
            
        }

        //[Fact(Skip = "niet klaar")]
        //public void Authentication_Works()
        //{
        //    Assert.Fail();
        //}
    }
}