using System;
using System.IO;

namespace AI_GM
{
    internal static class FilePaths
    {
        public static readonly string BaseDirectory = GetProjectRoot();

        private static string GetProjectRoot()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Traverse up until "AI-GM" is found in the directory path
            while (!string.IsNullOrEmpty(currentDirectory) && !currentDirectory.EndsWith(Path.DirectorySeparatorChar + "AI-GM"))
            {
                currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
            }

            return currentDirectory;
        }

        public static readonly string SAVEDCAMPAIGNS = Path.Combine(BaseDirectory, "SavedCampaigns");
        public static readonly string STARTINGROOMS = Path.Combine(BaseDirectory, "Map", "FirstRoomMaps.txt");
        public static readonly string MAINROOMS = Path.Combine(BaseDirectory, "Map", "Maps.txt");
        public static readonly string TOWN = Path.Combine(BaseDirectory, "Map", "TownMap.txt");
        public static readonly string EXITROOMS = Path.Combine(BaseDirectory, "Map", "ExitRooms.txt");
    }
}
