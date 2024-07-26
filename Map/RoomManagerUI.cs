using AI_GM.Characters;
using AI_GM.UserInterface;
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

        internal static ChangeFloor GetFloorChangeConfirmation()
        {
            ChangeFloor changeFloor = new ChangeFloor();
            changeFloor.LeaveFloor = UI.GetConfirmation("Are you sure you want to leave this floor?");
            if (changeFloor.LeaveFloor)
            {
                changeFloor.NextFloor = UI.GetConfirmation("Do you want to go to the next floor?");
                if (changeFloor.NextFloor)
                {
                    Console.WriteLine("Heading to the next floor");
                    return changeFloor;
                }
                changeFloor.LeaveDungeon = UI.GetConfirmation("Do you want to return to town?");
                if (changeFloor.LeaveDungeon)
                {
                    Console.WriteLine("Returning to town");
                    return changeFloor;
                }
                else
                {
                    Console.WriteLine("staying on this floor");
                    changeFloor.LeaveFloor = false;
                }
            }
            else
            {
                Console.WriteLine("staying on this floor");
            }
            return changeFloor;

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

        internal static void PrintPlayerCanMove(BlockedBy blockedBy, Character character)
        {
            switch (blockedBy)
            {
                case BlockedBy.None:
                    break;
                case BlockedBy.Wall:
                    break;
                case BlockedBy.Door:
                    break;
                case BlockedBy.NewFloor:
                    break;
                case BlockedBy.Trap:
                    Console.WriteLine("You have triggered a trap");
                    Console.WriteLine("You have taken 1 damage");
                    Console.WriteLine($"You have {character.MaxHitPoints = character.DamageTaken} health remain");
                    break;
                case BlockedBy.Shop:
                    break;
                case BlockedBy.Movement:
                    break;
                case BlockedBy.Monster:
                    Console.WriteLine("There is a monster in the way");
                    break;
                case BlockedBy.Chest:
                    Console.WriteLine("The path is blocked by a chest");
                    break;
            }
        }
    }
}
