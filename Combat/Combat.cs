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
            bool canAttack = CheckIfMonsterCanAttack(campaign, target, i);
            Monster monster = (Monster)campaign.CombatParticipants[i];
            Console.WriteLine($"{monster.Name}");
            if (canAttack)
            {
                while (true)
                {

                    int hits = GetHits(monster.AttackDice, EnumCombat.attack);
                    Console.WriteLine($"The monster has {hits} hits");
                    int defended = 0;
                    if (hits > 0)
                    {
                        int diceToDefend = campaign.CombatParticipants[target].DefendDice +
                                            campaign.PlayerCharacters[target].Armour.ExtraDice;
                        defended = GetHits(diceToDefend, EnumCombat.playerDefend);
                        Console.WriteLine($"You have defended {defended} hits ");
                    }
                    if (defended > hits)
                    {
                        defended = hits;
                    }

                    int damage = hits - defended;
                    Console.WriteLine($"You have taken {damage} damage");
                    Console.WriteLine($"You have {campaign.PlayerCharacters[target].MaxHitPoints - campaign.PlayerCharacters[target].DamageTaken} health remain");
                    campaign.CombatParticipants[target].DamageTaken += damage;

                    if (campaign.CombatParticipants[target].DamageTaken >= campaign.CombatParticipants[target].MaxHitPoints)
                    {
                        RoomManager.PlayerDeath();
                    }

                    break;

                }
            }     
        }

        private static bool CheckIfMonsterCanAttack(Campaign campaign, int target, int i)
        {
            int monsterX = campaign.CombatParticipants[i].X;
            int monsterY = campaign.CombatParticipants[i].Y;
            int attackRange = campaign.CombatParticipants[i].AttackRange;

            for (int checkX = monsterX - attackRange; checkX <= monsterX + attackRange; checkX++)
            {
                for (int checkY = monsterY - attackRange; checkY <= monsterY + attackRange; checkY++)
                {
                    if (campaign.CombatParticipants[target].X == checkX && campaign.CombatParticipants[target].Y == checkY)
                    {
                    return true;
                    }
                }
            }
            return false;
        }

        public static void PlayerAttackAction(ref Campaign campaign, int i)
        {
            IFightable selectedMonster = SelectMonsterFromParticipants(campaign.CombatParticipants);
            int diceToHit = campaign.PlayerCharacters[i].AttackDice + campaign.PlayerCharacters[i].Weapon.ExtraDice;
            int hits = GetHits(diceToHit, EnumCombat.attack);

            Console.WriteLine($"You have {hits} hits");
            int defended = 0;
            if (hits > 0)
            {
                defended = GetHits(selectedMonster.DefendDice, EnumCombat.monsterDefend);
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

        private static int GetHits(int diceCount, EnumCombat roll)
        {
            int hits = 0;
            for (int i = 0; i < diceCount; i++)
            {
                int result = Dice.DiceRoll(6);
                switch (roll)
                {
                    case EnumCombat.attack:
                        if (result <= 3)
                        {
                            hits++;
                        }
                        break;
                    case EnumCombat.playerDefend:
                        if (result >= 5)
                        {
                            hits++;
                        }
                        break;
                    case EnumCombat.monsterDefend:
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
                try
                {
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
                catch
                {
                    Console.WriteLine("Please enter a valid number");
                }
                
            }
        }
    }
}
