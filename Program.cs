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
                SaveLoad.SerializeCampaign(campaign);
            }
            else
            {
                campaign = SaveLoad.DeserializeCampaign();
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
            if (initSuccess == true)
            {
                //start game here, player 1 goes first, have 3 actions, when all 3 actions are done next player, when all players are done monsters
                //actions include move, attack and search, can not leave a room until all monsters are dead
                campaign.CombatParticipants = Combat.Combat.GetCombatParticipantsList(campaign);
                RoomManager.SpawnPlayer(campaign);
                RoomManager.CheckRoomLayout(campaign);
                while (true)
                {
                    for (int i = 0; i < campaign.CombatParticipants.Count; i++)
                    {
                        if (campaign.CombatParticipants[i].Identifier == Identifier.Player)
                        {
                            campaign = RoomManager.PlayersTurn(campaign, i);
                        }
                        else
                        {
                            RoomManager.MonstersTurn(campaign, i);
                        }
                    }
                }
            }
        }
    }
}