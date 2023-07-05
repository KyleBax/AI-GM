namespace AI_GM
{
    internal class CharacterCreation
    {
        /// <summary>
        /// runs the methods for character creation
        /// </summary>
        /// <returns></returns>
        public static Character NewCharacter()
        {
            while (true)
            {
                Character character = new Character();
                character.Name = CharacterCreationUI.GetCharacterName();
                character = CharacterCreationUI.SelectCharacterClass(character);
                character = CharacterCreationUI.SelectClassProficiencies(character);
                character = CharacterCreationLogic.AddClassFeatures(character);
                character = CharacterCreationUI.SelectCharacterSpecies(character);
                character = CharacterCreationLogic.AddSpeciesFeatures(character);
                character = CharacterCreationUI.StatPointDistribution(character);
                bool characterComplete = CharacterCreationUI.CharacterComplete(character, true);
                if (characterComplete)
                {
                    return character;
                }
            }
        }
    }
}
