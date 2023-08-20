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

        public static string LoadCampaign() //TODO see above method :P
        {
            Console.WriteLine("press Y to start a new campaign");
            string input = Console.ReadLine().ToLower();
            return input;
        }

        public static string GetInput()
        {
            Console.WriteLine("press d followed by the number you want to roll. example d8");
            string input = Console.ReadLine().ToLower();
            return input;
        }
    }
}
