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

        public static MonsterAttackResult MonsterAttack(ref Campaign campaign, int target, int i)
        {
            MonsterAttackResult result = new();
            bool canAttack = CheckIfMonsterCanAttack(campaign, target, i);
            Monster monster = (Monster)campaign.CombatParticipants[i];
            result.MonsterName = monster.Name;
            
            if (canAttack)
            {
                while (true)
                {
                    int hits = GetHits(monster.AttackDice, EnumCombat.attack);
                    result.Hits = hits;
                    int defended = 0;
                    if (hits > 0)
                    {
                        result.Missed = false;
                        int diceToDefend = campaign.CombatParticipants[target].DefendDice +
                                            campaign.PlayerCharacters[target].Armour.ExtraDice;
                        defended = GetHits(diceToDefend, EnumCombat.playerDefend);
                        result.DefendDice = defended;                 
                    }
                    else
                    {
                        result.Missed = true;
                    }
                    if (defended > hits)
                    {
                        defended = hits;
                    }

                    int damage = hits - defended;
                    result.Damage = damage;
                    result.HealthRemaining = campaign.PlayerCharacters[target].MaxHitPoints - campaign.PlayerCharacters[target].DamageTaken;

                    campaign.CombatParticipants[target].DamageTaken += damage;

                    if (campaign.CombatParticipants[target].DamageTaken >= campaign.CombatParticipants[target].MaxHitPoints)
                    {
                        RoomManager.PlayerDeath();
                    }

                    break;

                }
            }
            return result;
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

        public static PlayerAttackResult PlayerAttackAction(ref Campaign campaign, int activeCharactaer)
        {
            PlayerAttackResult result = new();

            IFightable selectedMonster = SelectMonsterFromParticipants(campaign.CombatParticipants);
            int diceToHit = campaign.PlayerCharacters[activeCharactaer].AttackDice + campaign.PlayerCharacters[activeCharactaer].Weapon.ExtraDice;
            int hits = GetHits(diceToHit, EnumCombat.attack);
            result.Hits = hits; 
            int defended = 0;
            if (hits > 0)
            {
                defended = GetHits(selectedMonster.DefendDice, EnumCombat.monsterDefend);
                result.DefendDice = defended;

            }
            if (defended > hits)
            {
                defended = hits;
            }

            int damage = hits - defended;
            result.Damage = damage;
            selectedMonster.DamageTaken += damage;
            if (selectedMonster.DamageTaken >= selectedMonster.MaxHitPoints)
            {
                result.Dead = true;
                //removes the selectedMonster from combatParticipants
                campaign.CombatParticipants.Remove(selectedMonster);               
            }
            else
            {
                result.Dead = false;
            }
            return result;
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
