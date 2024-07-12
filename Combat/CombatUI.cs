using AI_GM.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AI_GM.Combat
{
    internal class CombatUI
    {
        internal static void MonsterAttackUI(MonsterAttackResult result)
        {
            Console.WriteLine($"{result.MonsterName}");
            if (result.Missed)
            {
                Console.WriteLine($"The {result.MonsterName} misses");
            }
            else
            {
                Console.WriteLine($"The {result.MonsterName} has {result.Hits} hits");
                Console.WriteLine($"You have defended {result.DefendDice} hits");
                Console.WriteLine($"You have taken {result.Damage} damage");
                Console.WriteLine($"You have {result.HealthRemaining} health");
            }
        }

        internal static void PlayerAttackUI(PlayerAttackResult result)
        {
            Console.WriteLine("Player attacks");
            Console.WriteLine($"You have {result.Hits} hits");
            Console.WriteLine($"The Monster has defended {result.DefendDice} hits ");
            Console.WriteLine($"You have dealt {result.Damage} damage to the monster");
            if (result.Dead)
            {
                Console.WriteLine("you have killed this monster");
            }
        }
    }
}
