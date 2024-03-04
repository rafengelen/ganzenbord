using Ganzenbord.Business;
using Ganzenbord.Business.Dice;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;
using Moq;

namespace Ganzenbord.Unittests
{
    public class DiceTests
    {
        [Fact]
        public void WhenPlayerRolls2Dice_ThenGetDiceRollArrayOfLength2()
        {
            //ARRANGE
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            Mock<IDiceGenerator> diceGenerator = new Mock<IDiceGenerator>();
            IPlayer player = new RegularPlayer(mockLogger.Object, PlayerColor.Red);
            Game game = new Game(mockLogger.Object, diceGenerator.Object, PlayerType.Regular, 2, 1);
            game.Players = [player];
            //ACT
            int[] diceRolls = game.RollDice(2);

            //ASSERT
            Assert.Equal(2, diceRolls.Length);
        }

        // biedt geen meerwaarde, niet fout, maar gaan we niet testen
        /*
        [Fact]
        public void WhenPlayerRollsDice_ThenNumbersAreBetween1And6()
        {
            //ARRANGE
            Player player = new Player(PlayerColor.Red, new ConsoleLogger());

            //ACT
            int[] diceRolls = player.RollDice(20);

            //ASSERT
            foreach (int diceRoll in diceRolls)
            {
                Assert.InRange(diceRoll, 1, 6);
            }
        }
    */
    }
}