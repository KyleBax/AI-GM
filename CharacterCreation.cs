using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM
{
    internal class CharacterCreation
    {

        public static Character NewCharacter()
        {
            Character character = new Character();
            character.Name = GetCharacterName();
            character = SelectCharacterClass(character);
            character = SelectCharacterSpecies(character);
            character = StatPointDistribution(character);
            return character;
        }
        public static string GetCharacterName()
        {
            Console.WriteLine("Enter Character Name.");
            string name= Console.ReadLine();

            return name;
        }

        public static Character SelectCharacterClass(Character character)
        {
            List<string> classNames = NameLists.GetClassNames();
            Classes classes = new Classes();
            Console.WriteLine("select a class");
            for(int i = 0; i < classNames.Count; i++)
            {
                Console.WriteLine((i+1) + ": " + classNames[i]);
            }
            classes.Name = Console.ReadLine();
            character.Class = classes;
            return character;
        }

        public static Character SelectCharacterSpecies(Character character)
        {
            List<string> speciesNames = NameLists.GetSpeciesNames();
            Species species = new Species();
            Console.WriteLine("Select a species");
            for (int i = 0; i < speciesNames.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + speciesNames[i]);
            }
            species.Name = Console.ReadLine();
            character.Species = species;
            return character;
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
