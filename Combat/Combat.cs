using AI_GM.Characters;
using AI_GM.Monsters;
using System.Collections.Generic;

namespace AI_GM.Combat
{
    internal class Combat
    {
        /// <summary>
        /// The main method for the combat process
        /// </summary>
        /// <param name="campaign"></param>
        public static void CombatMain(Campaign campaign)
        {
            List<IFightable> combatParticipants = GetCombatParticipantsList(campaign);

            while (combatParticipants.Count >= 1)
            {
                for (int i = 0; i < combatParticipants.Count; i++)
                {

                    if (combatParticipants[i] is Character character)
                    {
                        PlayerTurn(combatParticipants, character);
                    }
                    if (combatParticipants[i] is Monster monster)
                    {
                        MonsterTurn(ref combatParticipants, monster);
                    }
                }
            }
        }

        /// <summary>
        /// Gets a random selection of monsters, and adds them to a list
        /// </summary>
        /// <returns></returns>
        public static List<Monster> GetMonsters()
        {
            Random random = new Random();
            List<Monster> monsters = new List<Monster>();
            Type type = typeof(MonsterName);
            Array monsterNames = type.GetEnumValues();
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = random.Next(monsterNames.Length);
                MonsterName monsterType = (MonsterName)monsterNames.GetValue(randomIndex);

                monsters.Add(GetMonsterStats(monsterType));
            }

            return monsters;
        }

        /// <summary>
        /// Adds all combat participants and then sorts them by initiative highest to lowest
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static List<IFightable> GetCombatParticipantsList(Campaign campaign)
        {
            Monster monster = new Monster();
            List<Monster> monsters = new List<Monster>();
            monsters = GetMonsters();
            List<IFightable> combatParticipants = new List<IFightable>();
            foreach (Character character in campaign.PlayerCharacters)
            {
                combatParticipants.Add(character);
            }
            foreach (Monster m in monsters)
            {
                combatParticipants.Add(m);
            }

            return combatParticipants;
        }

        public static void MonsterTurn(ref List<IFightable> combatParticipants, Monster monster)
        {
            if (monster.DamageTaken >= monster.MaxHitPoints)
            {
                Console.WriteLine($"{monster.Name}, {monster.Initiative}, has died");
                combatParticipants.Remove(monster);
                return;
            }
            else
            {
                Console.WriteLine($"{monster.Name}, {monster.Initiative}");
                //after making a map for the system, target closest oponnent
                int target = 0;
                while (true)
                {
                    if (combatParticipants[target].Identifier == Identifier.Monster)
                    {
                        target++;
                    }

                    if (combatParticipants[target].Identifier == Identifier.Player)
                    {
                        Console.WriteLine("target aqcuired");
                        int hits = GetHits(monster.AttackDice, "attack");
                        Console.WriteLine($"The monster has {hits} hits");
                        int defended = 0;
                        if (hits > 0)
                        {
                            defended = GetHits(combatParticipants[target].DefendDice, "monsterDefend");
                            Console.WriteLine($"You have defended {defended} hits ");
                        }
                        if (defended > hits)
                        {
                            defended = hits;
                        }

                        int damage = hits - defended;
                        Console.WriteLine($"You have taken {damage} damage");
                        combatParticipants[target].DamageTaken += damage;
                        break;
                    }
                }

            }
        }

        public static void PlayerTurn(List<IFightable> combatParticipants, Character character)
        {
            Console.WriteLine($"it is your turn {character.Name}");
            if (character.DamageTaken >= character.MaxHitPoints)
            {
                DeathSaves(character);
            }
            else
            {
                Console.WriteLine("Select an action");
                Console.WriteLine("move, attack, search"); //to be fully implemented

                PlayerAttackAction(ref combatParticipants, character);

            }

        }

        private static void PlayerAttackAction(ref List<IFightable> combatParticipants, Character character)
        {
            IFightable selectedMonster = SelectMonsterFromParticipants(combatParticipants);
            int hits = GetHits(character.AttackDice, "attack");

            Console.WriteLine($"You have {hits} hits");
            int defended = 0;
            if ( hits > 0 )
            {
                defended = GetHits(selectedMonster.DefendDice, "playerDefend");
                Console.WriteLine($"The Monster has defended {defended} hits ");
            }
            if(defended > hits)
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
                combatParticipants.Remove(selectedMonster);
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
                        if(result >= 5)
                        {
                            hits++;
                        }
                        break;
                    case "monsterDefend":
                        if(result == 4)
                        {
                            hits++;
                        }
                        break;
                }

            }
            return hits;
        }

        private static void DeathSaves(Character character)
        {
            Console.WriteLine($"{character.Name}, {character.Initiative}, you are dying. Make a death saving throw");

            int result = Dice.DiceRoll(20);
            switch (result)
            {
                case 1:
                    Console.WriteLine("You have suffered a critical death save");
                    character.DeathSaveFailure += 2;
                    break;
                case int n when n > 1 && n <= 10:
                    Console.WriteLine("You have failed a death save");
                    character.DeathSaveFailure += 1;
                    break;
                case int n when n > 10 && n <= 19:
                    Console.WriteLine("You have made a successful death save");
                    character.DeathSaveSuccess += 1;
                    break;
                case 20:
                    Console.WriteLine("You have made a successful death save");
                    character.DeathSaveSuccess += 2;
                    break;
            }

            if (character.DeathSaveFailure >= 3)
            {
                Console.WriteLine("You have died, please start a new campaign");
                // add player death effects here
            }

            if (character.DeathSaveSuccess >= 3)
            {
                Console.WriteLine("You have succeeded in avoiding death");
                while (character.DamageTaken >= character.MaxHitPoints)
                {
                    character.DamageTaken--;
                }
            }
        }

        private static IFightable SelectMonsterFromParticipants(List<IFightable> combatParticipants)
        {
            Console.WriteLine("choose a target");

            var selections = combatParticipants.Where(p => p.Identifier == Identifier.Monster).ToList();
            while(true)
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

        public static Monster GetMonsterStats(MonsterName monsterName)
        {
            Monster monster = new Monster();
            switch (monsterName)
            {
                case MonsterName.Goblin:
                    monster.Name = MonsterName.Goblin;
                    monster.AttackDice = 2;
                    monster.DefendDice = 2;
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
                    monster.MaxHitPoints = Dice.DiceCount("2d6");
                    monster.Initiative = Dice.DiceRoll(20) + monster.DexterityModifier;
                    monster.Attacks.Add(GetMonsterAttack(MonsterAttackType.Scimitar));
                    break;

                case MonsterName.PoisonousSnake:
                    monster.Name = MonsterName.PoisonousSnake;
                    monster.AttackDice = 2;
                    monster.DefendDice = 1;
                    monster.Strength = 2;
                    monster.StrengthModifier = -4;
                    monster.Dexterity = 16;
                    monster.DexterityModifier = 3;
                    monster.Constitution = 11;
                    monster.ConstitutionModifier = 0;
                    monster.Intelligence = 1;
                    monster.IntelligenceModifier = -5;
                    monster.Wisdom = 10;
                    monster.WisdomModifier = 0;
                    monster.Charisma = 3;
                    monster.CharismaModifier = -4;
                    monster.Speed = 30;
                    monster.MaxHitPoints = Dice.DiceRoll(4);
                    monster.Initiative = Dice.DiceRoll(20) + monster.DexterityModifier;
                    monster.Attacks.Add(GetMonsterAttack(MonsterAttackType.PoisonousSnakeBite));
                    break;

                case MonsterName.Rat:
                    monster.Name = MonsterName.Rat;
                    monster.AttackDice = 1;
                    monster.DefendDice = 1;
                    monster.Strength = 2;
                    monster.StrengthModifier = -4;
                    monster.Dexterity = 11;
                    monster.DexterityModifier = 0;
                    monster.Constitution = 9;
                    monster.ConstitutionModifier = -1;
                    monster.Intelligence = 2;
                    monster.IntelligenceModifier = -4;
                    monster.Wisdom = 10;
                    monster.WisdomModifier = 0;
                    monster.Charisma = 4;
                    monster.CharismaModifier = -3;
                    monster.Speed = 20;
                    monster.MaxHitPoints = Math.Max(Dice.DiceRoll(4) - 1, 1);
                    monster.Initiative = Dice.DiceRoll(20) + monster.DexterityModifier;
                    monster.Attacks.Add(GetMonsterAttack(MonsterAttackType.RatBite));
                    break;
                default:
                    break;
            }
            return monster;
        }

        public static MonsterAttack GetMonsterAttack(MonsterAttackType attackType)
        {
            MonsterAttack attack = new MonsterAttack();
            attack.Name = attackType;
            switch (attackType)
            {
                case MonsterAttackType.RatBite:
                    attack.HitModifier = 0;
                    attack.DamageModifier = 0;
                    attack.DamageDice = "1d4";
                    attack.DamageType = DamageType.Piercing;
                    break;
                case MonsterAttackType.PoisonousSnakeBite:
                    attack.HitModifier = 5;
                    attack.DamageModifier = 0;
                    attack.DamageDice = "2d4";
                    attack.DamageType = DamageType.Poison;
                    break;
                case MonsterAttackType.Scimitar:
                    attack.HitModifier = 4;
                    attack.DamageModifier = 2;
                    attack.DamageDice = "1d6";
                    attack.DamageType = DamageType.Slashing;
                    break;
            }

            return attack;
        }
    }
}
