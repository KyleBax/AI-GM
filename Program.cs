using AI_GM.Characters;
using AI_GM.Map;
using AI_GM.UserInterface;

namespace AI_GM
{
    internal class Program
    {
        public static void Main()
        {
         
            Campaign campaign = new Campaign();
            Character character = new Character();
            bool newCharacter = UI.GetConfirmation("press Y to start a new campaign");
            if (newCharacter)
            {
                character = CharacterCreation.NewCharacter(character);
                campaign.PlayerCharacters.Add(character);
                Logic.SerializeCampaign(campaign);
            }
            else
            {
                campaign = Logic.DeserializeCampaign();
                foreach (Character character1 in campaign.PlayerCharacters)
                {
                    CharacterCreationUI.CharacterComplete(character1, false);
                }

            }

            bool initSuccess = false;
            string input = UI.GetInput();
            if (input == "start")
            {
                initSuccess = RoomManager.InitialiseMaps(campaign);
            }
            if (input == "combat")
            {
                AI_GM.Combat.Combat.CombatMain(campaign);
            }
            if(initSuccess == true)
            {
                campaign = RoomManager.SpawnPlayer(campaign);
                RoomManager.CheckRoomLayout(campaign);
                List<Characters.Action> availableActions = RoomManager.GetListAvailablePlayerActions(campaign);
                RoomManager.DisplayAvailableActions(availableActions, campaign);


                ConsoleKeyInfo keyInfo;

                while ((keyInfo = Console.ReadKey()).Key != ConsoleKey.Escape)
                {
                    RoomManager.HandlePlayerMovement(keyInfo, campaign);
                    RoomManager.CheckRoomLayout(campaign);
                    availableActions = RoomManager.GetListAvailablePlayerActions(campaign);
                    RoomManager.DisplayAvailableActions(availableActions, campaign);
                }
            }
        }
    }
}