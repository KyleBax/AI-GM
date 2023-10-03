using AI_GM.Characters;

namespace AI_GM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character character = new Character();
            bool newCharacter = UI.GetConfirmation("press Y to start a new campaign");
            if (newCharacter)
            {
                character = CharacterCreation.NewCharacter(character);
                Logic.SerializeCharacter(character);
            }
            else
            {
                character = Logic.DeserializeCharacter();
                CharacterCreationUI.CharacterComplete(character, false);
            }
            string input = UI.GetInput();
            if (input == "combat")
            {
                Combat.CombatMain(character);
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("press d followed by the number you want to roll. example d8");
                    input = UI.GetInput();
                    int diceRoll;

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
}