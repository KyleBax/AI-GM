using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Map
{
    internal class RoomManagerUI
    {
        public static void PrintRoomCell(char roomCell)
        {
            Console.Write(roomCell);
        }

        internal static void NoPlayerFound()
        {
            Console.WriteLine("No character has been found, starting a new campaign");
        }

        internal static void OutOfActions()
        {
            Console.WriteLine("You are out of actions, move or end turn with N");
        }

        internal static void PlayerSpawnError(int playerCount)
        {
            Console.WriteLine($"Could not find enough 'S' in the room layout for all players. Found: {playerCount}");
        }
    }
}
