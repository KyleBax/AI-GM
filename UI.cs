namespace AI_GM
{
    internal class UI
    {
        public static string LoadCampaign()
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
