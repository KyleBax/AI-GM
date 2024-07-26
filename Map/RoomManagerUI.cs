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

        internal static bool EndTurn()
        {
            bool endTurnEarly;
            Console.WriteLine("All your available actions and movement will be reset");
            endTurnEarly = UI.GetConfirmation("Are you sure you want to end your turn?");
            if (endTurnEarly)
            {
                Console.WriteLine("Ending turn");
            }
            return endTurnEarly;
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

        internal static void PlayerDeath()
        {
            Console.WriteLine("You have died");
        }

        internal static void PlayerSpawnError(int playerCount)
        {
            Console.WriteLine($"Could not find enough 'S' in the room layout for all players. Found: {playerCount}");
        }

        internal static void PrintPlayerAction(ConsoleKeyInfo keyInfo, bool canDoAction, bool move, bool monsterPresent, 
            bool playerSearched, bool playerAttacked, int roll, int playerMovement)
        {
            Console.WriteLine();
            if (move)
            {
                return;
            }
            
            if (canDoAction)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.T:
                        Console.WriteLine("Player searches for traps.");
                        break;
                    case ConsoleKey.F:
                        if (monsterPresent)
                        {
                            Console.WriteLine("Unable to search while monsters are present");
                        }
                        else
                        {
                            if (playerSearched == true)
                            {
                                Console.WriteLine("Player searches for treasure.");
                            }
                            else
                            {
                                Console.WriteLine("Room is already searched try something else");
                            }
                        }
                        break;
                    case ConsoleKey.V:
                        if(playerAttacked == false)
                        {
                            Console.WriteLine("No monsters are within range");
                        }
                        break;
                    case ConsoleKey.R:
                        Console.WriteLine($"You have rolled {roll}, {playerMovement} movement available");
                        break;
                    case ConsoleKey.N:
                        break;
                    default:
                        // Handle other keys or provide a message for unknown keys
                        Console.WriteLine($"Unknown key: {keyInfo.Key}");
                        break;
                }
            }
            else
            {
                Console.WriteLine("You are out of actions, move or end turn with N");
            }

        }

        internal static void PrintPlayerCanMove(BlockedBy blockedBy, Character character)
        {
            switch (blockedBy)
            {
                case BlockedBy.Trap:
                    Console.WriteLine("You have triggered a trap");
                    Console.WriteLine("You have taken 1 damage");
                    Console.WriteLine($"You have {character.MaxHitPoints = character.DamageTaken} health remain");
                    break;
                case BlockedBy.Movement:
                    Console.WriteLine("You are out of movement");
                    break;
                case BlockedBy.Monster:
                    Console.WriteLine("There is a monster in the way");
                    break;
                case BlockedBy.Chest:
                    Console.WriteLine("The path is blocked by a chest");
                    break;
                default:
                    break;
            }
        }

        internal static void RoomCreationError()
        {
            Console.WriteLine("empty room. Unable to create room.");
        }

        public static void DisplayAvailableActions(List<Characters.Action> availableActions, Campaign campaign)
        {
            for (int i = 0; i < availableActions.Count; i++)
            {
                Console.WriteLine(availableActions[i]);
            }
        }
    }
}
