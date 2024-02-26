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

        public static List<Characters.Action> GetListAvailablePlayerActions(Campaign campaign, int availableMovementSpaces)
        {
            //check [character.x, character.y] ++ -- room.Layout
            int playerX = campaign.PlayerCharacters[campaign.ActivePlayer].X;
            int playerY = campaign.PlayerCharacters[campaign.ActivePlayer].Y;
            List<Characters.Action> availableActions = new List<Characters.Action>();
            bool moveAdded = false;


            for (int checkX = playerX - 1; checkX <= playerX + 1; checkX++)
            {
                for (int checkY = playerY - 1; checkY <= playerY + 1; checkY++)
                {
                    if (checkX == playerX && checkY == playerY)
                    {
                        // Skip the current position (character's position)
                        continue;
                    }

                    switch (room.Layout[checkY, checkX])
                    {
                        case ' ':
                            if (!moveAdded)  // Check if move option hasn't been added yet
                            {
                                if (availableMovementSpaces > 0)
                                {
                                    availableActions.Add(Characters.Action.Move);
                                }
                                else
                                {
                                    availableActions.Add(Characters.Action.RollToMove);
                                }
                                moveAdded = true;  // Set the flag to true after adding move option to prevent duplicates
                            }
                            break;
                        case 'm':
                            availableActions.Add(Characters.Action.Attack);
                            break;
                        case 'C':
                            availableActions.Add(Characters.Action.SearchChest);
                            break;

                        default:

                            break;
                    }
                }
            }
            return availableActions;

        }

        /// <summary>
        /// Handles player movement and actions
        /// w = move up, a = move left, s = move down, d = move right
        /// t = search for traps, f = search for treasure v = attack
        /// </summary>
        /// <param name="keyInfo"></param>
        public static Campaign HandlePlayerActions(ConsoleKeyInfo keyInfo, Campaign campaign)
        {
            int i = campaign.ActivePlayer;
            int currentX = campaign.PlayerCharacters[i].X;
            int currentY = campaign.PlayerCharacters[i].Y;

            Console.WriteLine();
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    // Move up logic
                    campaign.PlayerCharacters[i].AvailableMovement = TryMovePlayer(campaign, campaign.PlayerCharacters[i], currentX, currentY - 1, campaign.PlayerCharacters[i].AvailableMovement);
                    break;

                case ConsoleKey.A:
                    // Move left logic
                    campaign.PlayerCharacters[i].AvailableMovement = TryMovePlayer(campaign, campaign.PlayerCharacters[i], currentX - 1, currentY, campaign.PlayerCharacters[i].AvailableMovement);
                    break;

                case ConsoleKey.S:
                    // Move down logic
                    campaign.PlayerCharacters[i].AvailableMovement = TryMovePlayer(campaign, campaign.PlayerCharacters[i], currentX, currentY + 1, campaign.PlayerCharacters[i].AvailableMovement);
                    break;

                case ConsoleKey.D:
                    // Move right logic
                    campaign.PlayerCharacters[i].AvailableMovement = TryMovePlayer(campaign, campaign.PlayerCharacters[i], currentX + 1, currentY, campaign.PlayerCharacters[i].AvailableMovement);
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
                    // Combat.Combat.PlayerAttackAction(campaign.PlayerCharacters[i]);
                    Console.WriteLine("Player attacks");
                    break;
                case ConsoleKey.R:
                    //Roll for movement logic
                    int roll = Dice.DiceCount("2d4");
                    campaign.PlayerCharacters[i].AvailableMovement += roll;
                    Console.WriteLine($"You have rolled {roll}, {campaign.PlayerCharacters[i].AvailableMovement} movement available");
                    break;
                // Add more cases for other keys as needed

                default:
                    // Handle other keys or provide a message for unknown keys
                    Console.WriteLine($"Unknown key: {keyInfo.Key}");
                    break;
            }
            return campaign;
        }
        private static int TryMovePlayer(Campaign campaign, Character character, int targetX, int targetY, int availableMovementSpaces)
        {
            if (availableMovementSpaces > 0)
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
                            //deal damage to player here
                            character.DamageTaken += 1;
                            break;
                        case 'D':
                            LoadNewRoom();
                            newRoom = true;
                            playerLocationUpdated = false;
                            break;
                        case 'm':
                            Console.WriteLine("There is a monster in the way");
                            break;
                        default:
                            character.X = targetX;
                            character.Y = targetY;
                            break;
                    }
                    availableMovementSpaces--;
                }
                else
                {
                    Console.WriteLine("The path is blocked");
                }
            }
            else
            {
                Console.WriteLine("Please Roll before moving");
            }
            return availableMovementSpaces;
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
            for (int z = 0; z < campaign.PlayerCount; z++)
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

        internal static void DisplayAvailableActions(List<Characters.Action> availableActions, Campaign campaign)
        {
            for (int i = 0; i < availableActions.Count; i++)
            {
                Console.WriteLine(availableActions[i]);
            }
        }
    }
}
