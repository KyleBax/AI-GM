namespace AI_GM
{
    internal class Dice
    {
        public static int DiceRoll(int diceType, Random random)
        {
            int diceRoll = random.Next(1, diceType + 1);
            return diceRoll;
        }
    }
}
