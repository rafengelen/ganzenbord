using Ganzenbord.Business;
using Ganzenbord.Business.Player;

namespace Ganzenbord.Unittests
{
    public class GameTests
    {
        [Fact]
        public void WhenPlayerLandsOnInnAndSkipsTurn_ThenStaysOnPositionAndLowersSkipsAmount()
        {
            //arrange
            IPlayer player = PlayerHelper.GenerateTestPlayer(1);
            IGame game = PlayerHelper.GenerateGame([0,0]);

            game.Players = [player];
            player.AmountOfSkips = 1;

            //act
            game.PlayRound();

            //assert
            Assert.Equal(0, player.AmountOfSkips);
        }

        [Theory]
        [InlineData(new int[] { 3, 6 }, 0, 53, 1)]
        [InlineData(new int[] { 6, 3 }, 0, 53, 1)]
        public void WhenPlayerRolls3And5InTurn1_ThenGoTo52(int[] dice, int startPosition, int endPosition, int round)
        {
            //ARRANGE
            IPlayer player = PlayerHelper.GenerateTestPlayer(startPosition);
            IGame game = PlayerHelper.GenerateGame(dice);

            game.Players = [player];
            player.MoveToPosition(startPosition);
            game.Turn = round;

            //ACT
            game.PlayRound();

            //ASSERT
            Assert.Equal(endPosition, player.Position);
        }

        [Theory]
        [InlineData(new int[] { 6, 3 }, 0, 52, 2)]
        [InlineData(new int[] { 6, 3 }, 0, 52, 3)]
        [InlineData(new int[] { 3, 6 }, 0, 52, 2)]
        [InlineData(new int[] { 3, 6 }, 0, 52, 3)]
        public void WhenPlayerRolls3And6NotInTurn1_ThenNotGoTo52(int[] dice, int startPosition, int endPosition, int round)
        {
            //ARRANGE
            IPlayer player = PlayerHelper.GenerateTestPlayer(startPosition);
            IGame game = PlayerHelper.GenerateGame(dice);

            game.Players = [player];
            game.Turn = round;

            //ACT
            game.PlayRound();

            //ASSERT
            Assert.NotEqual(endPosition, player.Position);
        }

        [Theory]
        [InlineData(new int[] { 5, 4 }, 0, 26, 1)]
        [InlineData(new int[] { 4, 5 }, 0, 26, 1)]
        public void WhenPlayerRolls5And4InTurn1_ThenGoTo26(int[] dice, int startPosition, int endPosition, int round)
        {
            //ARRANGE
            IPlayer player = PlayerHelper.GenerateTestPlayer(1);
            IGame game = PlayerHelper.GenerateGame(dice);

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
            IPlayer player = PlayerHelper.GenerateTestPlayer(startPosition);
            IGame game = PlayerHelper.GenerateGame(dice);

            game.Players = [player];
            game.Turn = round;

            //ACT
            game.PlayRound();

            //ASSERT
            Assert.NotEqual(endPosition, player.Position);
        }

        [Fact]
        public void WhenPlayerRolls9NotInFirstTurn_ThenPlayerWins()
        {
            //ARRANGE
            int[] dice = [4, 5];
            IPlayer player = PlayerHelper.GenerateTestPlayer(0);
            IGame game = PlayerHelper.GenerateGame(dice);

            game.Players = [player];
            game.Turn = 2;

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.Equal(63, player.Position);
            Assert.True(player.IsWinner);
        }
    }
}