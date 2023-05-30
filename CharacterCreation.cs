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
            character.Class = SelectCharacterClass();
            character.Species = SelectCharacterSpecies();
            character = StatPointDistribution(character);
            return character;
        }
        public static string GetCharacterName()
        {
            Console.WriteLine("Enter Character Name.");
            string name= Console.ReadLine();

            return name;
        }

        public static string SelectCharacterClass()
        {
            //change so it prints the classes list as selectable options
            Console.WriteLine("select a class");
            Console.WriteLine("Cleric, Fighter, Rogue, Wizard");
            string className = Console.ReadLine();
            return className;
        }

        public static string SelectCharacterSpecies()
        {
            Console.WriteLine("Select a species");
            Console.WriteLine("Human, Elf, Dwarf");
            string species = Console.ReadLine();
            return species;
        }

        public static Character StatPointDistribution(Character character)
        {
            Console.WriteLine("you have 25 stat points to distribute");
            Console.WriteLine("current stats: Strength 10, Dexterity 10, Constitution 10, Intelligence 10, Wisdom 10, Charisma 10");
            Console.WriteLine("How would you like to distribute your points?");

            return character;
        }
    }
}
