namespace AI_GM
{
    internal class Combat
    {

        //TODO seperate the code into logic and UI
        public static void StartOfCombat(Character character)
        {
            Monster monster = new Monster();
            List<Monster> monsters = new List<Monster>();
            monsters = GetMonsters();

            Console.WriteLine("you are entering combat, roll initiative");
            character.Initiative = character.DexterityModifier + Dice.DiceRoll(20);
            Console.WriteLine($"You rolled {character.Initiative}");

            List<IFightable> combatParticipants = new List<IFightable>();

            monsters.Sort((monster1, monster2) => monster2.Initiative.CompareTo(monster1.Initiative));


            foreach (Monster m in monsters)                              //add all participants / then sort by initiatve
            {                                                            //add all participants / then sort by initiatve
                if (combatParticipants.Contains(character))              //add all participants / then sort by initiatve
                {                                                        //add all participants / then sort by initiatve
                    combatParticipants.Add(m);                           //add all participants / then sort by initiatve
                }                                                        //add all participants / then sort by initiatve
                else                                                     //add all participants / then sort by initiatve
                {                                                        //add all participants / then sort by initiatve
                    if (m.Initiative >= character.Initiative)            //add all participants / then sort by initiatve
                    {                                                    //add all participants / then sort by initiatve
                        combatParticipants.Add(m);                       //add all participants / then sort by initiatve
                    }                                                    //add all participants / then sort by initiatve
                    else                                                 //add all participants / then sort by initiatve
                    {                                                    //add all participants / then sort by initiatve
                        combatParticipants.Add(character);               //add all participants / then sort by initiatve
                        combatParticipants.Add(m);                       //add all participants / then sort by initiatve
                    }                                                    //add all participants / then sort by initiatve
                }                                                        //add all participants / then sort by initiatve
                                                                         //add all participants / then sort by initiatve
            }                                                            //add all participants / then sort by initiatve

            //add a player count for future
            while (combatParticipants.Count > 1)
            {
                for (int i = 0; i < combatParticipants.Count; i++)
                {
                    if (combatParticipants[i] is Character character1)
                    {                     

                        if(character1.DamageTaken >= character1.MaxHitPoints)
                        {
                            Console.WriteLine($"{character1.Name}, {character1.Initiative}, you are dying. Make a death saving throw");

                        }
                        else
                        {
                            Console.WriteLine($"{character1.Name}, {character1.Initiative}, your turn");
                            Console.WriteLine("choose a target");
                            // make it so that the user can pick a target
                           // int target;

                            for(int j = 0; j < combatParticipants.Count; j++)
                            {
                                Console.WriteLine(i + " " + combatParticipants[j].MaxHitPoints);
                            }
                            int selection = Int32.Parse(Console.ReadLine());

                            var target = combatParticipants[selection];



                            foreach (Monster m in combatParticipants)
                            {
                                Console.WriteLine(m.Name);
                            }
                            // select an attack to make
                            // spells, weapons etc
                            // roll a d20 to hit
                            // determine if hit (d20+toHitModifier >= monster.AC)
                            // on a hit deal damage, on a miss do nothing

                            
                            Console.ReadLine();
                        }
                        

                    }
                    if (combatParticipants[i] is Monster monster1)
                    {
                        if (monster1.DamageTaken == monster1.MaxHitPoints)
                        {
                            Console.WriteLine($"{monster1.Name}, {monster1.Initiative}, has died");
                            combatParticipants.Remove(i);
                        }
                        else
                        {
                            //after making a map for the system, target closest oponnent
                            int target = 1;
                            if (combatParticipants[target] is Monster)
                            {
                                //change target until it is a player
                            }

                            if (combatParticipants[target] is Character)
                            {
                                //attack
                            }

                            Console.WriteLine($"{monster1.Name}, {monster1.Initiative}");
                        }
                        
                    }
                }
            }
        }



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

        public static Monster GetMonsterStats(MonsterName monsterName)
        {
            Monster monster = new Monster();
            switch (monsterName)
            {
                case MonsterName.Goblin:
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
                    monster.MaxHitPoints = Dice.DiceCount("2d6");
                    monster.Initiative = Dice.DiceRoll(20) + monster.DexterityModifier;
                    break;

                case MonsterName.PoisonousSnake:
                    monster.Name = MonsterName.PoisonousSnake;
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
                    break;

                case MonsterName.Rat:
                    monster.Name = MonsterName.Rat;
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
                    monster.MaxHitPoints = Dice.DiceRoll(4)-1;
                    monster.Initiative = Dice.DiceRoll(20) + monster.DexterityModifier;
                    break;
                default:
                    break;
            }
            return monster;
        }
    }
}
