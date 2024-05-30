using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM
{
    internal class Controls
    {
        public static void PrintControls()
        {
            Console.WriteLine("Controls:");
            Console.WriteLine("Press R to roll dice to gain movement spaces");
            Console.WriteLine("Use W A S D to move");
            Console.WriteLine("When near a monster press V to attack");
            Console.WriteLine("Select which monster to attack by pressing the number corresponding to it followed by enter");
            Console.WriteLine("Search a room for traps by pressing T");
            Console.WriteLine("Search a room with a chest in it by pressing F");
        }
    }
}
