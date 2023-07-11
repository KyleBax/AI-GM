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
                    character.Class.HitDice = 8;
                    character.Class.SpellSlots = 3;
                    break;

                case "Fighter":
                    character.Class.HitDice = 10;
                    character.Class.SpellSlots = 0;
                    break;

                case "Wizard":
                    character.Class.HitDice = 6;
                    character.Class.SpellSlots = 3;
                    break;

                case "Rogue":
                    character.Class.HitDice = 8;
                    character.Class.SpellSlots = 0;
                    break;

                default:
                    return character;
            }

            character.Class.HitDiceCount = (int)Math.Ceiling((double)character.Class.Level / 3);
            Console.WriteLine(character.Class.HitDiceCount);

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
