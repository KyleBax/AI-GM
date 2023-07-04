namespace AI_GM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
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
                string input = UI.GetInput();
                int diceRoll;

                if (input.StartsWith("d") && input.Length > 1 && int.TryParse(input.Substring(1), out int diceType))
                {
                    diceRoll = Dice.DiceRoll(diceType, random);
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