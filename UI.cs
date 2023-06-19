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
    }
}
