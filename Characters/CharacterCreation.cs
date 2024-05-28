using AI_GM.UserInterface;

namespace AI_GM.Characters
{
    internal class CharacterCreation
    {
        /// <summary>
        /// runs the methods for character creation
        /// </summary>
        /// <returns>Character</returns>
        public static Character NewCharacter(Character character)
        {
            while (true)
            {
                character.Name = CharacterCreationUI.GetCharacterName();
                character = CharacterCreationUI.SelectCharacterClass(character);
                character = CharacterCreationLogic.AddClassFeatures(character);
                character = CharacterCreationUI.SelectCharacterSpecies(character);
                character = CharacterCreationLogic.AddSpeciesFeatures(character);
                bool characterComplete = CharacterCreationUI.CharacterComplete(character, true);
                character.Weapon = Items.Loot.GetStartingEquipment(true);
                character.Armour = Items.Loot.GetStartingEquipment(false);
                if (characterComplete)
                {
                    return character;
                }
            }
        }
    }
}
