namespace AI_GM
{
    internal class CharacterCreationLogic
    {
        public static Character AddClassFeatures(Character character)
        {
            //make a switch
            if (character.Class.Name == "Cleric")
            {
                character.Class.SpellSlots = 3;
            }
            if (character.Class.Name == "Fighter")
            {
                character.Class.SpellSlots = 0;
            }
            if (character.Class.Name == "Wizard")
            {
                character.Class.SpellSlots = 3;
            }
            if (character.Class.Name == "Rogue")
            {
                character.Class.SpellSlots = 0;
            }

            return character;
        }

        public static Character AddSpeciesFeatures(Character character)
        {
            return character;
        }
    }
}
