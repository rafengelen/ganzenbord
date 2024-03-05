using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;
using Moq;

namespace Ganzenbord.Unittests
{
    public class PlayerFactoryTests
    {
        [Fact]
        public void WhenTypeIsRegular_ThenCreateRegularPlayer()
        {
            //ARRANGE
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            IPlayerFactory playerFactory = new PlayerFactory();

            //ACT
            IPlayer player = playerFactory.Create(mockLogger.Object, PlayerType.Regular, PlayerColor.Red);

            //ASSERT
            Assert.Equal(typeof(RegularPlayer), player.GetType());
        }

        [Fact]
        public void WhenInvalidPlayerType_ThenThrowException()
        {
            // ARRANGE
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            PlayerType type = (PlayerType)999;
            string expectedMessage = $"Cannot find player type {type}";
            IPlayerFactory playerFactory = new PlayerFactory();

            // ACT + ASSERT
            var exceptionReturn = Assert.Throws<Exception>(() =>
            {
                playerFactory.Create(mockLogger.Object, type, PlayerColor.Red);
            });

            // ASSERT
            Assert.Equal(expectedMessage, exceptionReturn.Message);
        }
    }
}