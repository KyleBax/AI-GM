using AI_GM.Characters;
using System.Drawing;
using System.Numerics;

namespace AI_GM.Map
{
    internal class MapGenerator
    {
        public static Room room = new Room();
        public static void MapGeneratorMain(Campaign campaign)
        {
            
            List<Room> startingRooms = GetRoomsFromTextFile(@"C:\Repos\Rakete mentoring work\AI-GM\Map\FirstRoomMaps.txt");
            room = GetRandomRoom(startingRooms);
            Character character = campaign.PlayerCharacters.FirstOrDefault();

            if (character != null)
            {
                PlayerSpawn.SpawnPlayer(room, campaign);
                PrintRoomLayout(room, character);
                ConsoleKeyInfo keyInfo;

                while ((keyInfo = Console.ReadKey()).Key != ConsoleKey.Escape)
                {
                    HandlePlayerMovement(keyInfo, campaign, character);
                    PrintRoomLayout(room, character);
                }
            }
            else
            {
                Console.WriteLine("No character has been found, starting a new campaign");
                Program.Main();
            }


        }
        /// <summary>
        /// Handles player movement and actions
        /// w = move up, a = move left, s = move down, d = move right
        /// t = search for traps, f = search for treasure v = attack
        /// </summary>
        /// <param name="keyInfo"></param>
        public static void HandlePlayerMovement(ConsoleKeyInfo keyInfo, Campaign campaign, Character character)
        {
            int currentX = character.X;
            int currentY = character.Y;

            Console.WriteLine();
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    // Move up logic                  
                    TryMovePlayer(campaign, character, currentX, currentY - 1);
                    break;

                case ConsoleKey.A:
                    // Move left logic
                    TryMovePlayer(campaign, character, currentX - 1, currentY);
                    break;

                case ConsoleKey.S:
                    // Move down logic
                    TryMovePlayer(campaign, character, currentX, currentY + 1);
                    break;

                case ConsoleKey.D:
                    // Move right logic
                    TryMovePlayer(campaign, character, currentX + 1, currentY);
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
            if (IsMoveValid(room, campaign, targetX, targetY))
            {
                if (room.Layout[targetY, targetX] == 'D')
                {
                    LoadNewRoom();
                }
                else
                {
                    UpdateRoomLayout(character, targetX, targetY);
                }
            }
            else
            {
                Console.WriteLine("The path is blocked");
            }
        }

        private static void UpdateRoomLayout(Character character, int targetX, int targetY)
        {
            room.Layout[character.Y, character.X] = ' ';
            room.Layout[targetY, targetX] = 'X';
            character.X = targetX;
            character.Y = targetY;
        }

        private static void LoadNewRoom()
        {
            List<Room> rooms = GetRoomsFromTextFile(@"C:\Repos\Rakete mentoring work\AI-GM\Map\Maps.txt");
            room = GetRandomRoom(rooms);

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
        private static bool IsMoveValid(Room room, Campaign campaign, int targetX, int targetY)
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
        private static Room GetRandomRoom(List<Room> rooms)
        {
            int randomRoomNumber = Dice.DiceRoll(rooms.Count) - 1;
            Room room = rooms[randomRoomNumber];
            return room;
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


        public static void PrintRoomLayout(Room room, Character character)
        {
            for (int i = 0; i < room.Layout.GetLength(0); i++)
            {
                for (int j = 0; j < room.Layout.GetLength(1); j++)
                {
                    if (i == character.Y && j == character.X)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(room.Layout[i, j]);
                    }

                }
                Console.WriteLine();
            }
        }


    }
}
