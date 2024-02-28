using Ganzenbord.Business;

namespace Ganzenbord.Unittests
{
    public class DiceTests
    {
        [Fact]
        public void WhenPlayerRolls2Dice_ThenGetDiceRollArrayOfLength2()
        {
            //ARRANGE
            Player player = new Player();

            //ACT
            int[] diceRolls = player.RollDice(2);

            //ASSERT
            Assert.Equal(2, diceRolls.Length);
        }

        [Fact]
        public void WhenPlayerRollsDice_ThenNumbersAreBetween1And6()
        {
            //ARRANGE
            Player player = new Player();

            //ACT
            int[] diceRolls = player.RollDice(20);

            //ASSERT
            foreach (int diceRoll in diceRolls)
            {
                Assert.InRange(diceRoll, 1, 6);
            }
        }
    }
}