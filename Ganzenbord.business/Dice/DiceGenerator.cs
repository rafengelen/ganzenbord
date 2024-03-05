namespace Ganzenbord.Business.Dice
{
    public class DiceGenerator() : IDiceGenerator
    {
        private Random random = new Random();

        public int[] RollDice(int amountOfDice)
        {
            int[] dice = new int[amountOfDice];
            for (int i = 0; i < amountOfDice; i++)
            {
                dice[i] = random.Next(1, 7);
            }

            return dice;
        }
    }
}