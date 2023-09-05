using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM
{
    internal class Combat
    {
        public static void StartOfCombat(Character character)
        {
            Monster monster = new Monster();
            List<Monster> monsters = new List<Monster>();
            monster = GetMonster(); //TODO create a method that randomises how many monsters and what type of monster they are
            monsters.Add(monster);  //Make it so that it automates their initiative at creation also

            monster = GetMonster();
            monsters.Add(monster);

            Console.WriteLine("you are entering combat, roll initiative");
            character.Initiative = character.DexterityModifier + Dice.DiceRoll(20);
            Console.WriteLine($"You rolled {character.Initiative}");
            Console.WriteLine($"You are face to face with a {monster.Name}");
            // TODO add a method that determines the order of combat based on the higher initiative roll
            List<object> combatParticipants = new List<object>();

            monsters.Sort((monster1, monster2) => monster2.Initiative.CompareTo(monster1.Initiative));


            foreach (Monster m in monsters)
            {
                if (combatParticipants.Contains(character))
                {
                    combatParticipants.Add(m);
                }
                else
                {
                    if (m.Initiative >= character.Initiative)
                    {
                        combatParticipants.Add(m);
                    }
                    else
                    {
                        combatParticipants.Add(character);
                        combatParticipants.Add(m);
                    }
                }

            }

            for (int i = 0; i < combatParticipants.Count; i++)
            {
                if (combatParticipants[i] is Character character1)
                {
                    Console.WriteLine($"{character1.Name}, {character1.Initiative}");
                }
                if (combatParticipants[i] is Monster monster1)
                {
                    Console.WriteLine($"{monster1.Name}, {monster1.Initiative}");
                }
            }
        }



        public static Monster GetMonster() //TODO add more monsters and make these methods select from multiple options
        {
            Monster monster = new Monster();
            monster = Goblin(monster);
            return monster;
        }

        public static Monster Goblin(Monster monster)
        {
            monster.Name = MonsterName.Goblin;
            monster.Strength = 8;
            monster.StrengthModifier = -1;
            monster.Dexterity = 14;
            monster.DexterityModifier = 2;
            monster.Constitution = 10;
            monster.ConstitutionModifier = 0;
            monster.Intelligence = 10;
            monster.IntelligenceModifier = 0;
            monster.Wisdom = 8;
            monster.WisdomModifier = -1;
            monster.Charisma = 8;
            monster.CharismaModifier = -1;
            monster.Speed = 30;
            monster.HitPoints = Dice.DiceRoll(6) + Dice.DiceRoll(6);  //TODO change DiceRoll method to take diceCount also
            monster.Initiative = Dice.DiceRoll(20);
            return monster;
        }
    }
}
