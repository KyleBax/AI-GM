using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using AI_GM.Characters;

namespace AI_GM.UserInterface
{
    internal static class CharacterCreationUI
    {
        public static string GetCharacterName()
        {
            Console.WriteLine("Enter Character Name.");
            string name = Console.ReadLine();

            return name;
        }

        public static Character MultichoiceListSelections<T>(Character character, List<T> options, List<T> targetList)
        {
            bool makeSelection = true;
            while (makeSelection)
            {
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine(i + 1 + ": " + options[i]);
                }
                int selectedProficiencyIndex;
                if (int.TryParse(Console.ReadLine(), out selectedProficiencyIndex) && selectedProficiencyIndex >= 1 && selectedProficiencyIndex <= options.Count)
                {
                    targetList.Add(options[selectedProficiencyIndex - 1]);
                    Console.WriteLine("Proficiency selected: " + options[selectedProficiencyIndex - 1]);

                    makeSelection = false;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }
            return character;
        }

        public static T Select<T>()
        {
            string[] enumNames = Enum.GetNames(typeof(T));

            Console.WriteLine("Available options:");
            for (int i = 0; i < enumNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {enumNames[i]}");
            }
            Console.WriteLine("Enter the corresponding number of the desired option: ");
            int selectedIndex;
            while (!int.TryParse(Console.ReadLine(), out selectedIndex) || selectedIndex < 1 || selectedIndex > enumNames.Length)
            {
                Console.WriteLine("Invalid option");
            }

            T selectedEnumValue = (T)Enum.Parse(typeof(T), enumNames[selectedIndex - 1]);

            return selectedEnumValue;
        }





        public static Character SelectCharacterClass(Character character)
        {
            Console.WriteLine("select a class");

            character.Class.Name = Select<Class>();
            return character;
        }

        public static Character SelectClassProficiencies(Character character)
        {
            List<Skill> proficiencies = new();
            int proficiencyCount;
            switch (character.Class.Name)
            {
                case Class.Cleric:
                    proficiencies = new List<Skill> { Skill.Survival, Skill.Medicine, Skill.Religion, Skill.Perception, Skill.Persuasion, Skill.History };
                    proficiencyCount = 2;
                    break;

                case Class.Fighter:
                    proficiencies = new List<Skill> { Skill.Acrobatics, Skill.Atheletics, Skill.Insight, Skill.Survival, Skill.Perception, Skill.History };
                    proficiencyCount = 2;
                    break;

                case Class.Wizard:
                    proficiencies = new List<Skill> { Skill.Insight, Skill.Arcana, Skill.Medicine, Skill.Insight, Skill.Investigation, Skill.History };
                    proficiencyCount = 2;
                    break;

                case Class.Rogue:
                    proficiencies = new List<Skill> { Skill.Stealth, Skill.SleightOfHand, Skill.Acrobatics, Skill.Perception, Skill.Persuasion, Skill.Deception };
                    proficiencyCount = 3;
                    break;

                default:
                    return character;
            }
            while (proficiencyCount >= 1)
            {
                Console.WriteLine("Select your proficiencies");
                Console.WriteLine("enter the number that corresponds to the proficiencies you would like to choose");
                character = MultichoiceListSelections(character, proficiencies, character.SkillsProficiencies);
                proficiencyCount -= 1;
            }
            return character;
        }

        public static Character SelectCharacterSpecies(Character character)
        {
            Console.WriteLine("Select a species");

            character.Species.Name = Select<Specie>();
            return character;
        }

        public static Character SelectSpeciesFeatures(Character character)
        {
            List<Language> languages;
            List<Skill> proficiencies;
            int languageCount;
            int proficiencyCount;
            switch (character.Species.Name)
            {
                case Specie.Human:
                    languages = new List<Language> { Language.Giant, Language.Dwarvish, Language.Elvish, Language.Celestial };
                    languageCount = 2;
                    proficiencyCount = 2;
                    proficiencies = new List<Skill> { Skill.Atheletics, Skill.Perception, Skill.Religion, Skill.Survival };
                    break;

                case Specie.Elf:
                    languages = new List<Language> { Language.Dwarvish, Language.Celestial };
                    languageCount = 1;
                    proficiencyCount = 1;
                    proficiencies = new List<Skill> { Skill.Acrobatics, Skill.Perception, Skill.Medicine, Skill.Nature };
                    break;

                case Specie.Dwarf:
                    languages = new List<Language> { Language.Elvish, Language.Giant };
                    languageCount = 1;
                    proficiencyCount = 1;
                    proficiencies = new List<Skill> { Skill.Atheletics, Skill.Intimidation, Skill.History, Skill.Survival };
                    break;

                default:
                    return character;
            }

            while (languageCount >= 1)
            {
                Console.WriteLine("Select your languages");
                Console.WriteLine("enter the number that corresponds to the languages you would like to choose");
                character = MultichoiceListSelections(character, languages, character.Species.Languages);
                languageCount -= 1;
            }

            while (proficiencyCount >= 1)
            {
                Console.WriteLine("Select your proficiencies");
                Console.WriteLine("enter the number that corresponds to the proficiencies you would like to choose");
                character = MultichoiceListSelections(character, proficiencies, character.SkillsProficiencies);
                proficiencyCount -= 1;
            }

            return character;
        }

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
