using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;
using Ganzenbord.Business.Squares;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord.Unittests
{
    public class PlayerFactoryTests
    {
        [Fact]
        public void WhenTypeIsRegular_ThenCreateRegularPlayer()
        {
            //ARRANGE
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            //ACT
            IPlayer player = PlayerFactory.Create(mockLogger.Object, PlayerType.Regular, PlayerColor.Red);

            //ASSERT
            Assert.Equal(typeof(RegularPlayer), player.GetType());
        }
        [Fact]
        public void WhenTypeIsNotDefines_ThenThrowException()
        {
            // ARRANGE
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            PlayerType type = (PlayerType)999; // An undefined type
            string expectedMessage = $"Cannot find player type {type}";

            // ACT + ASSERT
            var exceptionReturn = Assert.Throws<Exception>(() =>
            {
                PlayerFactory.Create(mockLogger.Object, type, PlayerColor.Red);
            });

            // ASSERT
            Assert.Equal(expectedMessage, exceptionReturn.Message);
        }
    }
}
