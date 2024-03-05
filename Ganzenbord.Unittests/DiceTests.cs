using Ganzenbord.Business.Dice;

namespace Ganzenbord.Unittests
{
    public class DiceTests
    {
        [Fact]
        public void WhenPlayerRolls2Dice_ThenGetDiceRollArrayOfLength2()
        {
            //ARRANGE
            IDiceGenerator diceGenerator = new DiceGenerator();

            //ACT
            int[] diceRolls = diceGenerator.RollDice(2);

            //ASSERT
            Assert.Equal(2, diceRolls.Length);
        }
    }
}