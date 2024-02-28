using Ganzenbord.Business;

namespace Ganzenbord.Unittests
{
    public class SquareTests
    {
        [Fact]
        public void WhenPlayerLandsOnBridge_ThenPutPlayerOnSquare12()
        {
            //arrange
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
            Player player = new Player();
            player.MoveToPosition(28);
            int[] dice = { 1, 2 };

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.Fail();
        }

        [Fact]
        public void WhenPlayerLandsOnMaze_ThenPutPlayerOnSquare39()
        {
            //arrange
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
        {/*
            //arrange

            Player player = new Player();
            Player[] players = { player };
            game.Players = players;
            player.MoveToPosition(55);
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

            //assert
            Assert.False(player.Game.Active);*/
            Assert.Fail();
        }

        //[Fact(Skip = "niet klaar")]
        //public void Authentication_Works()
        //{
        //    Assert.Fail();
        //}
    }
}