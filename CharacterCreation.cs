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
            Classes classes = new Classes();
            //change so it prints the classes list as selectable options
            Console.WriteLine("select a class");
            Console.WriteLine("Cleric, Fighter, Rogue, Wizard");
            classes.Name = Console.ReadLine();
            character.Class = classes;
            return character;
        }

        public static Character SelectCharacterSpecies(Character character)
        {
            Species species = new Species();
            Console.WriteLine("Select a species");
            Console.WriteLine("Human, Elf, Dwarf");
            species.Name = Console.ReadLine();
            character.Species = species;
            return character;
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
