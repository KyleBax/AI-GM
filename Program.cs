namespace AI_GM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character character = new Character();

            string newCharacter = UI.LoadCampaign();
            if(newCharacter == "y")
            {
                character = CharacterCreation.NewCharacter();
            }
            else
            {

            }



        }
    }
}