namespace AI_GM
{
    internal class CharacterCreationLogic
    {
        public static Character AddClassFeatures(Character character)
        {
            character.Class.ProficiencyWeapons = new();
            character.Class.ProficiencyArmour = new();
            character.Class.Level = 1;

            switch (character.Class.Name)
            {
                case "Cleric":
                    character.Class.HitDice = 8;
                    character.Class.SpellSlots = 3;
                    character.Class.ProficiencyWeapons.Add("Simple Weapons");
                    character.Class.ProficiencyArmour.Add("Light Armour");
                    character.Class.ProficiencyArmour.Add("Medium Armour");
                    break;

                case "Fighter":
                    character.Class.HitDice = 10;
                    character.Class.SpellSlots = 0;
                    character.Class.ProficiencyWeapons.Add("Simple Weapons");
                    character.Class.ProficiencyWeapons.Add("Martial Weapons");
                    character.Class.ProficiencyArmour.Add("Heavy Armour");
                    character.Class.ProficiencyArmour.Add("Light Armour");
                    character.Class.ProficiencyArmour.Add("Medium Armour");
                    break;

                case "Wizard":
                    character.Class.HitDice = 6;
                    character.Class.SpellSlots = 3;
                    character.Class.ProficiencyWeapons.Add("Daggers");
                    character.Class.ProficiencyWeapons.Add("Darts");
                    character.Class.ProficiencyWeapons.Add("Quarterstaffs");
                    character.Class.ProficiencyArmour.Add("Light Armour");
                    break;

                case "Rogue":
                    character.Class.HitDice = 8;
                    character.Class.SpellSlots = 0;
                    character.Class.ProficiencyWeapons.Add("Simple Weapons");
                    character.Class.ProficiencyWeapons.Add("Longswords");
                    character.Class.ProficiencyWeapons.Add("Rapiers");
                    character.Class.ProficiencyWeapons.Add("Shortswords");
                    character.Class.ProficiencyArmour.Add("Light Armour");
                    break;

                default:
                    return character;
            }

            character.Class.HitDiceCount = (int)Math.Ceiling((double)character.Class.Level / 3);
            Console.WriteLine(character.Class.HitDiceCount);

            //add class specific abilities here


            return character;
        }

        public static Character AddSpeciesFeatures(Character character)
        {


            return character;
        }
    }
}
