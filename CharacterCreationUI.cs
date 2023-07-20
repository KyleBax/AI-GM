using System.ComponentModel;

namespace AI_GM
{
    internal class CharacterCreationUI
    {
        public static string GetCharacterName()
        {
            Console.WriteLine("Enter Character Name.");
            string name = Console.ReadLine();

            return name;
        }

        public static Character SelectCharacterClass(Character character)
        {
            List<string> classNames = NameLists.GetClassNames();
            Classes classes = new Classes();
            Console.WriteLine("select a class");
            Console.WriteLine("enter the number that corresponds to the class you would like to choose");
            while (true)
            {
                for (int i = 0; i < classNames.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + classNames[i]);
                }
                int selectedClassIndex;
                if (int.TryParse(Console.ReadLine(), out selectedClassIndex) && selectedClassIndex >= 1 && selectedClassIndex <= classNames.Count)
                {
                    classes.Name = classNames[selectedClassIndex - 1];
                    character.Class = classes;
                    Console.WriteLine("Class selected: " + classes.Name);
                    return character;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }
        }

        public static Character SelectClassProficiencies(Character character)
        {
            List<string> proficiencies = new();
            int proficiencyCount;
            switch (character.Class.Name)
            {
                case "Cleric":
                    proficiencies = NameLists.GetClericProficiencies();
                    proficiencyCount = 2;
                    break;

                case "Fighter":
                    proficiencies = NameLists.GetFighterProficiencies();
                    proficiencyCount = 2;
                    break;

                case "Wizard":
                    proficiencies = NameLists.GetWizardProficiencies();
                    proficiencyCount = 2;
                    break;

                case "Rogue":
                    proficiencies = NameLists.GetRogueProficiencies();
                    proficiencyCount = 3;
                    break;

                default:
                    return character;
            }
            while (proficiencyCount >= 1)
            {
                Console.WriteLine("Select your proficiencies");
                Console.WriteLine("enter the number that corresponds to the proficiencies you would like to choose");
                bool selectProficiency = true;
                while (selectProficiency)
                {
                    for (int i = 0; i < proficiencies.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ": " + proficiencies[i]);
                    }
                    int selectedProficiencyIndex;
                    if (int.TryParse(Console.ReadLine(), out selectedProficiencyIndex) && selectedProficiencyIndex >= 1 && selectedProficiencyIndex <= proficiencies.Count)
                    {
                        switch (proficiencyCount)
                        {
                            case 1:
                                character.Class.SkillProficiency1 = proficiencies[selectedProficiencyIndex - 1];
                                Console.WriteLine("Proficiency selected: " + character.Class.SkillProficiency1);
                                break;
                            case 2:
                                character.Class.SkillProficiency2 = proficiencies[selectedProficiencyIndex - 1];
                                Console.WriteLine("Proficiency selected: " + character.Class.SkillProficiency2);
                                break;
                            case 3:
                                character.Class.SkillProficiency3 = proficiencies[selectedProficiencyIndex - 1];
                                Console.WriteLine("Proficiency selected: " + character.Class.SkillProficiency3);
                                break;
                        }
                        selectProficiency = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please try again.");
                    }
                }
                proficiencyCount -= 1;
            }
            return character;
        }

        public static Character SelectCharacterSpecies(Character character)
        {
            List<string> speciesNames = NameLists.GetSpeciesNames();
            Species species = new Species();
            Console.WriteLine("Select a species");
            Console.WriteLine("enter the number that corresponds to the class you would like to choose");
            while (true)
            {
                for (int i = 0; i < speciesNames.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + speciesNames[i]);
                }
                int selectedSpeciesIndex;
                if (int.TryParse(Console.ReadLine(), out selectedSpeciesIndex) && selectedSpeciesIndex >= 1 && selectedSpeciesIndex <= speciesNames.Count)
                {
                    species.Name = speciesNames[selectedSpeciesIndex - 1];
                    character.Species = species;
                    Console.WriteLine("Species selected: " + species.Name);
                    return character;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }
        }
        
/*        public static Character SelectSpeciesFeatures(Character character)
        {
            List<string> languages = new();
            switch (character.Species.Name)
            {
                case "Human":
                    languages = NameLists.GetClericProficiencies();
                    languageCount = 2;
                    break;

                case "Elf":
                    proficiencies = NameLists.GetFighterProficiencies();
                    proficiencyCount = 2;
                    break;

                case "Dwarf":
                    proficiencies = NameLists.GetWizardProficiencies();
                    proficiencyCount = 2;
                    break;

                default:
                    return character;
            }

            return character;
        }*/

        public static bool CharacterComplete(Character character, bool newCharacter)
        {
            Console.WriteLine($"Name:{character.Name}, Class: {character.Class.Name}, Species: {character.Species.Name}");
            Console.WriteLine($"STR:{character.Strength}, DEX: {character.Dexterity}, CON: {character.Constitution}, INT: {character.Intelligence}, WIS: {character.Wisdom}, CHA: {character.Charisma}");
            if (newCharacter)
            {
                Console.WriteLine("Are you happy with your character? Y/N?");
                if (Console.ReadLine().ToLower() == "y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public static Character StatPointDistribution(Character character)
        {
            character.Strength = 10;
            character.Dexterity = 10;
            character.Constitution = 10;
            character.Intelligence = 10;
            character.Wisdom = 10;
            character.Charisma = 10;

            Console.WriteLine("You have 25 stat points to distribute.");
            Console.WriteLine("Current stats: Strength 10, Dexterity 10, Constitution 10, Intelligence 10, Wisdom 10, Charisma 10");
            Console.WriteLine("How would you like to distribute your points?");
            Console.WriteLine("Please enter the number of points you want to assign for each stat (separated by spaces):");

            string input = Console.ReadLine();
            string[] pointValues = input.Split(' ');

            if (pointValues.Length != 6)
            {
                Console.WriteLine("Invalid input. Please provide values for all 6 stats.");
                return StatPointDistribution(character);
            }

            int totalPoints = 25;
            int[] stats = new int[6];
            int allocatedPoints = 0;

            for (int i = 0; i < stats.Length; i++)
            {
                if (!int.TryParse(pointValues[i], out int points) || points < 0 || points > totalPoints - allocatedPoints)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number of points for each stat.");
                    return StatPointDistribution(character);
                }

                stats[i] = points;
                allocatedPoints += points;
            }

            // Assign the allocated stat points to the character
            character.Strength += stats[0];
            character.Dexterity += stats[1];
            character.Constitution += stats[2];
            character.Intelligence += stats[3];
            character.Wisdom += stats[4];
            character.Charisma += stats[5];

            Console.WriteLine("Stat points distributed successfully.");

            return character;
        }
    }
}
