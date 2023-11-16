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

       

        public static Character SelectCharacterSpecies(Character character)
        {
            Console.WriteLine("Select a species");

            character.Species.Name = Select<Specie>();
            return character;
        }

       

        public static bool CharacterComplete(Character character, bool newCharacter)
        {
            Console.WriteLine($"Name:{character.Name}, Class: {character.Class.Name}, Species: {character.Species.Name}");
            // Console.WriteLine($"STR:{character.Strength}, DEX: {character.Dexterity}, CON: {character.Constitution}, INT: {character.Intelligence}, WIS: {character.Wisdom}, CHA: {character.Charisma}");
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
    }
}
