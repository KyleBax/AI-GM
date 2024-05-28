using AI_GM.Characters;
using AI_GM.Map;
using AI_GM.Monsters;
using System.Xml.Linq;

namespace AI_GM.Combat
{
    internal class Combat
    {
        /// <summary>
        /// Adds player characters to cambatparticipant list
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        public static List<IFightable> GetCombatParticipantsList(Campaign campaign)
        {
            List<IFightable> combatParticipants = new List<IFightable>();
            foreach (Character character in campaign.PlayerCharacters)
            {
                combatParticipants.Add(character);
            }

            return combatParticipants;
        }

        public static void MonsterAttack(ref Campaign campaign, int target, int i)
        {
            Monster monster = (Monster)campaign.CombatParticipants[i];
            Console.WriteLine($"{monster.Name}");
            while (true)
            {

                int hits = GetHits(monster.AttackDice, "attack");
                Console.WriteLine($"The monster has {hits} hits");
                int defended = 0;
                if (hits > 0)
                {
                    defended = GetHits(campaign.CombatParticipants[target].DefendDice, "monsterDefend");
                    Console.WriteLine($"You have defended {defended} hits ");
                }
                if (defended > hits)
                {
                    defended = hits;
                }

                int damage = hits - defended;
                Console.WriteLine($"You have taken {damage} damage");
                campaign.CombatParticipants[target].DamageTaken += damage;

                if (campaign.CombatParticipants[target].DamageTaken >= campaign.CombatParticipants[target].MaxHitPoints)
                {
                    RoomManager.PlayerDeath();
                }

                break;

            }
        }

        public static void PlayerAttackAction(ref Campaign campaign, int i)
        {
            IFightable selectedMonster = SelectMonsterFromParticipants(campaign.CombatParticipants);
            int hits = GetHits(campaign.PlayerCharacters[i].AttackDice, "attack");

            Console.WriteLine($"You have {hits} hits");
            int defended = 0;
            if (hits > 0)
            {
                defended = GetHits(selectedMonster.DefendDice, "playerDefend");
                Console.WriteLine($"The Monster has defended {defended} hits ");
            }
            if (defended > hits)
            {
                defended = hits;
            }

            int damage = hits - defended;

            Console.WriteLine($"You have dealt {damage} damage to the monster");

            selectedMonster.DamageTaken += damage;
            if (selectedMonster.DamageTaken >= selectedMonster.MaxHitPoints)
            {
                Console.WriteLine("you have killed this monster");
                //removes the selectedMonster from combatParticipants
                campaign.CombatParticipants.Remove(selectedMonster);

                campaign = Items.Loot.AddNewItem(campaign, i, false);                
            }

        }

        private static int GetHits(int diceCount, string roll)
        {
            int hits = 0;
            for (int i = 0; i < diceCount; i++)
            {
                int result = Dice.DiceRoll(6);
                switch (roll)
                {
                    case "attack":
                        if (result <= 3)
                        {
                            hits++;
                        }
                        break;
                    case "playerDefend":
                        if (result >= 5)
                        {
                            hits++;
                        }
                        break;
                    case "monsterDefend":
                        if (result == 4)
                        {
                            hits++;
                        }
                        break;
                }

            }
            return hits;
        }

        private static IFightable SelectMonsterFromParticipants(List<IFightable> combatParticipants)
        {
            Console.WriteLine("choose a target");

            var selections = combatParticipants.Where(p => p.Identifier == Identifier.Monster).ToList();
            while (true)
            {
                for (int i = 0; i < selections.Count; i++)
                {
                    if (selections[i].Identifier == Identifier.Monster)
                    {
                        Console.WriteLine(i + 1 + " " + selections[i].Identifier);
                    }

                }
                int selection = int.Parse(Console.ReadLine());

                if (selection >= 1 && selection <= selections.Count)
                {
                    return selections[selection - 1];
                }
                else
                {
                    Console.WriteLine("Invalid Selection");
                    Console.WriteLine("Select one of these options");
                }
            }
        }
    }
}
