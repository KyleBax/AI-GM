using AI_GM.Characters;
using System.Drawing;
using System.Numerics;
using static AI_GM.Map.EnumDoorSide;

namespace AI_GM.Map
{
    internal class RoomManager
    {
        public static List<Room>? mainRooms;
        public static Room room = new Room();
        public static bool newRoom = false;
        public static bool playerLocationUpdated = true;
        public static bool InitialiseMaps(Campaign campaign)
        {
            mainRooms = GetRoomsFromTextFile(FilePaths.MAINROOMS);
            List<Room> startingRooms = GetRoomsFromTextFile(FilePaths.STARTINGROOMS);
            GetRandomRoom(startingRooms);
            Character character = campaign.PlayerCharacters.FirstOrDefault();

            if (character != null)
            {                
                return true;
            }
            else
            {
                Console.WriteLine("No character has been found, starting a new campaign");
                return false;
            }


        }
        public static Campaign SpawnPlayer(Campaign campaign)
        {
            int desiredPlayerCount = campaign.PlayerCharacters.Count;
            int playerCount = 0;

            // Iterate through the room layout
            for (int i = 0; i < room.Layout.GetLength(0); i++)
            {
                for (int j = 0; j < room.Layout.GetLength(1); j++)
                {
                    if (room.Layout[i, j] == 'S')
                    {
                        // Update character's X and Y based on 'S' position
                        Character character = campaign.PlayerCharacters[playerCount];
                        character.X = j;
                        character.Y = i;

                        room.Layout[i, j] = ' ';

                        Console.WriteLine($"{character.X}, {character.Y}");

                        playerCount++;

                        if (playerCount >= desiredPlayerCount)
                        {
                            // Replace all remaining 'S' occurrences with spaces
                            for (int m = i; m < room.Layout.GetLength(0); m++)
                            {
                                for (int n = 0; n < room.Layout.GetLength(1); n++)
                                {
                                    if (room.Layout[m, n] == 'S')
                                    {
                                        room.Layout[m, n] = ' ';
                                    }
                                }
                            }
                            return campaign;
                        }
                    }
                }
            }

            Console.WriteLine($"Could not find enough 'S' in the room layout for all players. Found: {playerCount}");
            return campaign;
        }

        public static void GetAvailablePlayerActions(Character character)
        {
            //check [character.x, character.y] ++ -- room.Layout
            int x = character.X;
            int y = character.Y;
            
        }

        /// <summary>
        /// Handles player movement and actions
        /// w = move up, a = move left, s = move down, d = move right
        /// t = search for traps, f = search for treasure v = attack
        /// </summary>
        /// <param name="keyInfo"></param>
        public static void HandlePlayerMovement(ConsoleKeyInfo keyInfo, Campaign campaign)
        {
            int i = campaign.ActivePlayer -1;
            int currentX = campaign.PlayerCharacters[i].X;
            int currentY = campaign.PlayerCharacters[i].Y;

            Console.WriteLine();
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    // Move up logic                  
                    TryMovePlayer(campaign, campaign.PlayerCharacters[i], currentX, currentY - 1);
                    break;

                case ConsoleKey.A:
                    // Move left logic
                    TryMovePlayer(campaign, campaign.PlayerCharacters[i], currentX - 1, currentY);
                    break;

                case ConsoleKey.S:
                    // Move down logic
                    TryMovePlayer(campaign, campaign.PlayerCharacters[i], currentX, currentY + 1);
                    break;

                case ConsoleKey.D:
                    // Move right logic
                    TryMovePlayer(campaign, campaign.PlayerCharacters[i], currentX + 1, currentY);
                    break;

                case ConsoleKey.T:
                    // Search for traps logic
                    Console.WriteLine("Player searches for traps.");


                    break;

                case ConsoleKey.F:
                    // Search for treasure logic
                    Console.WriteLine("Player searches for treasure.");
                    break;

                case ConsoleKey.V:
                    // combat logic
                    Console.WriteLine("Player attacks");
                    break;

                // Add more cases for other keys as needed

                default:
                    // Handle other keys or provide a message for unknown keys
                    Console.WriteLine($"Unknown key: {keyInfo.Key}");
                    break;
            }
        }
        private static void TryMovePlayer(Campaign campaign, Character character, int targetX, int targetY)
        {
            if (IsTargetInBounds(room, campaign, targetX, targetY))
            {
                switch (room.Layout[targetY, targetX])
                {
                    
                    case 'C':
                        Console.WriteLine("The path is blocked by a chest");
                        break;
                    case 'T':
                        Console.WriteLine("You have triggered a trap");
                        character.X = targetX;
                        character.Y = targetY;
                        break;
                    case 'D':
                        LoadNewRoom();
                        newRoom = true;
                        playerLocationUpdated = false;
                        break;
                    default:
                        character.X = targetX;
                        character.Y = targetY;
                        break;
                }
            }
            else
            {
                Console.WriteLine("The path is blocked");
            }
        }

        private static void LoadNewRoom()
        {
            GetRandomRoom(mainRooms);
        }

        /// <summary>
        /// checks to make sure the move is valid by checking it is inside the room and not in the space of an object
        /// that can not be 
        /// </summary>
        /// <param name="room"></param>
        /// <param name="campaign"></param>
        /// <param name="targetX"></param>
        /// <param name="targetY"></param>
        /// <returns></returns>
        private static bool IsTargetInBounds(Room room, Campaign campaign, int targetX, int targetY)
        {
            // Check if the target position is within the bounds of the room
            if (targetX >= 0 && targetX < room.Layout.GetLength(1) &&
                targetY >= 0 && targetY < room.Layout.GetLength(0))
            {
                // Check if the target position is not a wall ('#')
                return room.Layout[targetY, targetX] != '#';
            }

            return false;
        }


        /// <summary>
        /// Gets a random number and uses that to select the room that appears
        /// </summary>
        /// <param name="rooms"></param>
        /// <returns></returns>
        private static void GetRandomRoom(List<Room> rooms)
        {
            int randomRoomNumber = Dice.DiceRoll(rooms.Count) - 1;
            room = rooms[randomRoomNumber];
        }

        /// <summary>
        /// seperates the rooms in the text files, using "ROOM" as the divider, then adds them to a list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns name="rooms"></returns>
        public static List<Room> GetRoomsFromTextFile(string filePath)
        {
            List<Room> rooms = new List<Room>();
            string[] lines = File.ReadAllLines(filePath);

            List<string> currentRoom = new List<string>();
            foreach (string line in lines)
            {
                if (line.Trim().Equals("ROOM"))
                {
                    Room newRoom = CreateRoom(currentRoom);
                    rooms.Add(newRoom);
                    currentRoom.Clear();
                }
                else
                {
                    currentRoom.Add(line);
                }
            }

            return rooms;
        }
        /// <summary>
        /// takes from the l
        /// </summary>
        /// <param name="currentRoom"></param>
        /// <returns></returns>
        private static Room CreateRoom(List<string> currentRoom)
        {
            Room newRoom = new Room();
            if (currentRoom.Count > 0)
            {

                int rows = currentRoom.Count;
                int columns = currentRoom.Max(row => row.Length);

                char[,] layout = new char[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    int currentRowLength = currentRoom[i].Length;


                    for (int j = 0; j < columns; j++)
                    {
                        layout[i, j] = currentRoom[i][j];
                    }
                    for (int j = currentRowLength; j < columns; j++)
                    {
                        layout[i, j] = ' ';
                    }
                }

                newRoom.Layout = layout;
            }
            else
            {
                Console.WriteLine("empty room. Unable to create room.");
            }
            return newRoom;
        }


        public static void CheckRoomLayout(Campaign campaign)
        {
            for(int z = 0; z< campaign.PlayerCount; z++)
            {
                for (int i = 0; i < room.Layout.GetLength(0); i++)
                {
                    for (int j = 0; j < room.Layout.GetLength(1); j++)
                    {
                        if (newRoom == true)
                        {
                            if (room.Layout[i, j] == 'D')
                            {
                                switch (FindDoorSide(room, i, j))
                                {
                                    case DoorSide.Right:
                                        campaign.PlayerCharacters[z].Y = i;
                                        campaign.PlayerCharacters[z].X = j - 1;
                                        break;
                                    case DoorSide.Left:
                                        campaign.PlayerCharacters[z].Y = i;
                                        campaign.PlayerCharacters[z].X = j + 1;
                                        break;
                                    case DoorSide.Bottom:
                                        campaign.PlayerCharacters[z].Y = i - 1;
                                        campaign.PlayerCharacters[z].X = j;
                                        break;
                                    case DoorSide.Top:
                                        campaign.PlayerCharacters[z].Y = i + 1;
                                        campaign.PlayerCharacters[z].X = j;
                                        break;
                                }
                                playerLocationUpdated = true;
                                newRoom = false;
                            }
                        }
                        PrintRoomLayout(i, j, campaign.PlayerCharacters[z]);
                    }
                    Console.WriteLine();
                }
            }

            

        }

        private static DoorSide FindDoorSide(Room room, int i, int j)
        {
            if (j == room.Layout.GetLength(1) - 1)
                return DoorSide.Right;

            if (j == 0)
                return DoorSide.Left;

            if (i == room.Layout.GetLength(0) - 1)
                return DoorSide.Bottom;

            if (i == 0)
                return DoorSide.Top;

            return DoorSide.Right; 
        }





        public static void PrintRoomLayout(int i, int j, Character character)
        {
            if (i == character.Y && j == character.X && playerLocationUpdated)
            {
                Console.Write('X');
            }
            else
            {
                if (room.Layout[i, j] == 'T')
                {
                    Console.Write(' ');
                }
                else
                {
                    Console.Write(room.Layout[i, j]);
                }

            }
        }


    }
}
