namespace AI_GM
{
    internal static class Dice
    {
        private static Random rng = new Random();   
        public static int DiceRoll(int diceType)
        {
            int diceRoll = rng.Next(1, diceType + 1);
            return diceRoll;
        }
    }
}
