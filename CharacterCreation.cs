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
        
        //stat point distribution
        //class
        //species
    }
}
