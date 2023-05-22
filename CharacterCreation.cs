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
        
        //stat point distribution
        //species
    }
}
