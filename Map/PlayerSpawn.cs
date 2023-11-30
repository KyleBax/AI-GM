using AI_GM.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Map
{
    internal class PlayerSpawn
    {
        public static void SpawnPlayer(Room room, Campaign campaign)
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

                        // Update the room layout with 'X' at the player's position
                        room.Layout[i, j] = ' ';

                        Console.WriteLine($"{character.X}, {character.Y}");

                        playerCount++;

                        // Exit the loop once all players are spawned
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

                            return;
                        }
                    }
                }
            }

            Console.WriteLine($"Could not find enough 'S' in the room layout for all players. Found: {playerCount}");
        }

    }
}
