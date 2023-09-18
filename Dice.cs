using System;
using System.IO;

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

        public static int DiceCount(string input)
        {
            int total = 0;
            string[] parts = input.Split('d');
            if (parts.Length == 2 && int.TryParse(parts[0], out int numDice) && int.TryParse(parts[1], out int diceType))
            {
                for (int i = 0; i < numDice; i++)
                {
                    int roll = DiceRoll(diceType);
                    total += roll;
                }
            }
            return total;
        }
    }
}
