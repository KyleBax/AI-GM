using System.Drawing;

namespace AI_GM.Map
{
    internal class MapGenerator
    {
        public static void MapGeneratorMain()
        {
            List<Room> rooms = GetRoomsFromTextFile(@"C:\Repos\Rakete mentoring work\AI-GM\Map\Maps.txt");
            List<Room> startingRooms = GetRoomsFromTextFile(@"C:\Repos\Rakete mentoring work\AI-GM\Map\FirstRoomMaps.txt");
            Room room = GetRandomRoom(startingRooms);
            PlayerSpawn.SpawnPlayer(room, 2, 3);

            PrintRoomLayout(room);
        }

        public void HandlePlayerMovement()
        {

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


        public static void PrintRoomLayout(Room room)
        {
            for (int i = 0; i < room.Layout.GetLength(0); i++)
            {
                for (int j = 0; j < room.Layout.GetLength(1); j++)
                {
                    Console.Write(room.Layout[i, j]);
                }
                Console.WriteLine();
            }
            //Point positon
        }

        
    }
}
