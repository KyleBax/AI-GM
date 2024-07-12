using AI_GM.Characters;
using AI_GM.Combat;
using AI_GM.Map;
using AI_GM.UserInterface;

namespace AI_GM
{
    internal class Program
    {
        public static void Main()
        {
            bool campaignActive = true;
            Campaign campaign = new Campaign();
            Character character = new Character();
            UI.PrintControls();
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
                if (campaign != null)
                {
                    foreach (Character character1 in campaign.PlayerCharacters)
                    {
                        CharacterCreationUI.CharacterComplete(character1, false);
                    }
                }
                else
                {
                    UI.ErrorMessage();
                }

            }

            bool initSuccess = RoomManager.InitialiseMaps(campaign);
            campaign.inTown = true;

            if (initSuccess == true)
            {
                //start game here, player 1 goes first, have 3 actions, when all 3 actions are done next player, when all players are done monsters
                //actions include move, attack and search, can not leave a room until all monsters are dead
                campaign.CombatParticipants = Combat.Combat.GetCombatParticipantsList(campaign);
                RoomManager.SpawnPlayer(campaign);
                RoomManager.CheckRoomLayout(campaign);
                RoomManager.PrintRoomLayout(campaign);
                while (campaignActive)
                {
                    for (int i = 0; i < campaign.CombatParticipants.Count; i++)
                    {
                        if (campaign.CombatParticipants[i].Identifier == Identifier.Player)
                        {
                            campaign = RoomManager.PlayersTurn(campaign, i);
                            if (campaign.PlayerCharacters.Count <= 0)
                            {
                                UI.GameOver();
                                
                                campaignActive = false;
                                break;
                            }
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