



namespace AI_GM.UserInterface
{
    internal class UI
    {
        public static bool GetConfirmation(string promt)
        {
            Console.WriteLine(promt);
            string input = Console.ReadLine().ToLower();
            return input == "y";
        }

        public static string GetInput()
        {
            string input = Console.ReadLine().ToLower();
            return input;
        }

        public static int GetIntInput()
        {
            int input = int.Parse(Console.ReadLine());
            return input;
        }

        public static void PrintControls()
        {
            Console.WriteLine("Controls:");
            Console.WriteLine("Press R to roll dice to gain movement spaces");
            Console.WriteLine("Use W A S D to move");
            Console.WriteLine("When near a monster press V to attack");
            Console.WriteLine("Select which monster to attack by pressing the number corresponding to it followed by enter");
            Console.WriteLine("Search a room for traps by pressing T");
            Console.WriteLine("Search a room with a chest in it by pressing F");
        }

        internal static void ErrorMessage()
        {
            Console.WriteLine("Something went wrong");
        }

        internal static void GameOver()
        {
            Console.WriteLine("Game Over");
        }
        
        internal static void MonsterTurnStart()
        {
            Console.WriteLine("monster turn");
        }
    }
}
