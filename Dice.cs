using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM
{
    internal class Dice
    {
        public static int DiceRoll(int diceType)
        {
            Random random = new Random();
            int diceRoll = random.Next(1, diceType + 1);
            return diceRoll;    
        }
    }
}
