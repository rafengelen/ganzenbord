using Ganzenbord.Business;

namespace Ganzenbord.Unittests
{
    public class PlayerMovementTests
    {
        [Fact]
        public void WhenPlayerRollsDice_ThenPlayerMoves()
        {
            //arrange
            Player player = new Player();
            player.MoveToPosition(1);
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

            //assert
            Assert.Equal(4, player.Position);
        }

        [Fact]
        public void WhenPlayerMovesFurtherThan63_ThenPlayerWalksRemainingStepsBackwards()
        {
            //arrange
            Player player = new Player();
            player.MoveToPosition(62);
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

            //assert
            Assert.Equal(61, player.Position);
        }
    }
}