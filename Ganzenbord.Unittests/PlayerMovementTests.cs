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
            IPlayer player = PlayerHelper.GenerateTestPlayer(1);
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
            IPlayer player = PlayerHelper.GenerateTestPlayer(1);
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
            IPlayer player = PlayerHelper.GenerateTestPlayer(62);
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

            //assert
            Assert.Equal(61, player.Position);
        }
    }
}