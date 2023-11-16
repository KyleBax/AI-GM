using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Map
{
    internal class MapGenerator
    {
        public static void MapGeneratorMain()
        {
            List<Room> rooms = GetRoomsFromTextFile(@"C:\Repos\Rakete mentoring work\AI-GM\Map\Maps.txt");
            List<Room> startingRooms = GetRoomsFromTextFile(@"C:\Repos\Rakete mentoring work\AI-GM\Map\FirstRoomMaps.txt");
            Room room = GetRandomRoom(startingRooms);
            PrintRoomLayout(room);
        }

        private static Room GetRandomRoom(List<Room> rooms)
        {
            int randomRoomNumber = Dice.DiceRoll(rooms.Count) - 1;
            Room room = rooms[randomRoomNumber];
            return room;
        }

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

                newRoom.layout = layout;
            }
            else
            {
                Console.WriteLine("empty room. Unable to create room.");
            }
            return newRoom;
        }

        public static void PrintRoomLayout(Room room)
        {
            for (int i = 0; i < room.layout.GetLength(0); i++)
            {
                for (int j = 0; j < room.layout.GetLength(1); j++)
                {
                    Console.Write(room.layout[i, j]);
                }
                Console.WriteLine();
            }
        }


    }
}
