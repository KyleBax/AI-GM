namespace AI_GM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character character = new Character();

            character = CharacterCreation.NewCharacter();

            Console.WriteLine($"{character.Name}, {character.Class}");


        }
    }
}