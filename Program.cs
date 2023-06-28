namespace AI_GM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character character = new Character();

            string newCharacter = UI.LoadCampaign();
            if (newCharacter == "y")
            {
                character = CharacterCreation.NewCharacter();
                Logic.SerializeCharacter(character);
            }
            else
            {
                character = Logic.DeserializeCharacter();
                CharacterCreationUI.CharacterComplete(character, false);
            }
            while (true)
            {
                Console.WriteLine("press d followed by the number you want to roll. example d8");
                string input = Console.ReadLine().ToLower();
                int diceRoll = -1;

                if (input.StartsWith("d") && input.Length > 1 && int.TryParse(input.Substring(1), out int diceType))
                {
                    diceRoll = Dice.DiceRoll(diceType);
                    Console.WriteLine(diceRoll);
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }



        }
    }
}