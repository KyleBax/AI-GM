using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Map
{
    internal class PlayerSpawn
    {
        public static void SpawnPlayer(Room room, int x, int y)
        {
            // Check if the provided coordinates are within the bounds of the room
            if (x >= 0 && x < room.Layout.GetLength(0) && y >= 0 && y < room.Layout.GetLength(1))
            {
                room.Layout[x, y] = 'X';

                // Replace any other 'S' with ' ' in the room
                for (int i = 0; i < room.Layout.GetLength(0); i++)
                {
                    for (int j = 0; j < room.Layout.GetLength(1); j++)
                    {
                        if (room.Layout[i, j] == 'S' && (i != x || j != y))
                        {
                            room.Layout[i, j] = ' ';
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid coordinates for spawning the player.");
            }
        }
    }
}
