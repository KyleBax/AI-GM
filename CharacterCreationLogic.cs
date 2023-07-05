namespace AI_GM
{
    internal class CharacterCreationLogic
    {
        public static Character AddClassFeatures(Character character)
        {
            character.Class.Level = 1;

            switch (character.Class.Name)
            {
                case "Cleric":
                    character.Class.SpellSlots = 3;
                    break;

                case "Fighter":
                    character.Class.SpellSlots = 0;
                    break;

                case "Wizard":
                    character.Class.SpellSlots = 3;
                    break;

                case "Rogue":
                    character.Class.SpellSlots = 0;
                    break;

                default:
                    return character;
            }

            //add class specific abilities here
            //add class specific weapon proficiencies here


            return character;
        }

        public static Character AddSpeciesFeatures(Character character)
        {


            return character;
        }
    }
}
