using AI_GM.Characters;
using AI_GM.Monsters;

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
                        MonsterTurn(combatParticipants, monster);
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
           // combatParticipants.Sort((x, y) => y.Initiative.CompareTo(x.Initiative));

            return combatParticipants;
        }

        /// <summary>
        /// gets player initiative, and tells the player what their initiative is
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static int GetPlayerInitiative(Character character)
        {
            Console.WriteLine("you are entering combat, roll initiative");
            int initiative = character.DexterityModifier + Dice.DiceRoll(20);
            Console.WriteLine($"You rolled {initiative}");
            return initiative;
        }

        public static void MonsterTurn(List<IFightable> combatParticipants, Monster monster)
        {
            if (monster.DamageTaken == monster.MaxHitPoints)
            {
                Console.WriteLine($"{monster.Name}, {monster.Initiative}, has died");
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
                        // if target is within range of an attack, perform attack else move speed toward target
                        // if target is within range of  an attack, attack, else move speed toward target then end turn

                        // change so that it is DiceRoll + attack.HitModifier
                        int attackRoll = Dice.DiceRoll(20) + 5;

                        bool hit = CheckIfHit(combatParticipants[target].ArmourClass, attackRoll);
                        if (hit)
                        {
                            int damage = MonsterDealDamage(monster);
                            combatParticipants[target].DamageTaken += damage;
                        }
                        break;
                    }
                }

            }
        }

        public static bool CheckIfHit(int targetAC, int attackRoll)
        {
            bool hit = false;
            if (attackRoll >= targetAC)
            {
                hit = true;
            }
            return hit;
        }

        public static int MonsterDealDamage(Monster monster)
        {
            int damage = 1;

            return damage;
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


                IFightable slectedMonster = SelectMonsterFromParticipants(combatParticipants);

                Console.WriteLine($"{character.Name}, {character.Initiative}, your turn");
                Console.WriteLine("choose a target");


                var selections = combatParticipants.Where(p => p.Identifier == Identifier.Monster).ToList();



                for (int j = 0; j < combatParticipants.Count; j++)
                {
                    if (combatParticipants[j].Identifier == Identifier.Monster)
                    {
                        Console.WriteLine(j + 1 + " " + combatParticipants[j].Identifier);
                    }

                }
                int selection = int.Parse(Console.ReadLine());

                Attack attack = SelectAttack(character);

                int attackRoll = Dice.DiceRoll(20);

                bool hit = DetermineIfHit(attack, character, attackRoll);

                if (hit)
                {
                    int damage = GetDamage(attack, character);
                    // add damage to target monster

                }



                Console.ReadLine();
            }

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

        private static int GetDamage(Attack attack, Character character)
        {
            throw new NotImplementedException();
        }

        private static bool DetermineIfHit(Attack attack, Character character, int attackRoll)
        {
            throw new NotImplementedException();
        }

        private static Attack SelectAttack(Character character)
        {
            throw new NotImplementedException();
        }

        private static IFightable SelectMonsterFromParticipants(List<IFightable> fightables)
        {
            throw new NotImplementedException();
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
