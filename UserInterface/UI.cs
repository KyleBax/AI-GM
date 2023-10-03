namespace AI_GM
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
    }
}
