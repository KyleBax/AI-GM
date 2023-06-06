using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM
{
    internal class NameLists
    {
        public static List<string> GetClassNames()
        {
            List<string> classNames = new List<string>();

            classNames.Add("Cleric");
            classNames.Add("Fighter");
            classNames.Add("Wizard");
            classNames.Add("Rogue");

            return classNames;
        }

        public static List<string> GetSpeciesNames()
        {
            List<string> speciesNames = new List<string>();

            speciesNames.Add("Human");
            speciesNames.Add("Elf");
            speciesNames.Add("Dwarf");

            return speciesNames;
        }
    }
}
