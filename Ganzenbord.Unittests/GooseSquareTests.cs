using Ganzenbord.Business;
using Ganzenbord.Business.GameBoard;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord.Unittests
{
    public class GooseSquareTests
    {
        [Theory]
        [InlineData(new int[] { 1, 1 }, 3,7 )]
        [InlineData(new int[] { 2, 1 }, 38, 44)]
        [InlineData(new int[] { 3, 3 }, 8, 20)]
        public void WhenPlayerLandsOnGoose_ThenGoForwardSameAmountOfSteps(int[] dice, int startPosition, int endPosition)
        {
            //ARRANGE
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            IPlayer player = new Player(mockLogger.Object, PlayerColor.Red);
            GameTmp game = new GameTmp(mockLogger.Object,[player], GameBoardType.GooseGame);
            player.MoveToPosition(startPosition);

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.Equal(endPosition, player.Position);
        }
    }
}
