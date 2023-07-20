namespace AI_GM
{
    internal class CharacterCreationLogic
    {
        public static Character AddClassFeatures(Character character)
        {
            character.Class.ProficiencyWeapons = new();
            character.Class.ProficiencyArmour = new();
            character.Class.Abilities = new();
            character.Class.Level = 1;

            switch (character.Class.Name)
            {
                case "Cleric":
                    character.Class.HitDice = 8;
                    character.Class.SpellSlots = 3;
                    character.Class.ProficiencyWeapons.Add("Simple Weapons");
                    character.Class.ProficiencyArmour.Add("Light Armour");
                    character.Class.ProficiencyArmour.Add("Medium Armour");
                    //this is a place holder until I work out exactly what they should be
                    character.Class.Abilities.Add("Ability 1");
                    character.Class.Abilities.Add("Ability 2");
                    break;

                case "Fighter":
                    character.Class.HitDice = 10;
                    character.Class.SpellSlots = 0;
                    character.Class.ProficiencyWeapons.Add("Simple Weapons");
                    character.Class.ProficiencyWeapons.Add("Martial Weapons");
                    character.Class.ProficiencyArmour.Add("Heavy Armour");
                    character.Class.ProficiencyArmour.Add("Light Armour");
                    character.Class.ProficiencyArmour.Add("Medium Armour");
                    //this is a place holder until I work out exactly what they should be
                    character.Class.Abilities.Add("Ability 1");
                    character.Class.Abilities.Add("Ability 2");
                    break;

                case "Wizard":
                    character.Class.HitDice = 6;
                    character.Class.SpellSlots = 3;
                    character.Class.ProficiencyWeapons.Add("Daggers");
                    character.Class.ProficiencyWeapons.Add("Darts");
                    character.Class.ProficiencyWeapons.Add("Quarterstaffs");
                    character.Class.ProficiencyArmour.Add("Light Armour");
                    //this is a place holder until I work out exactly what they should be
                    character.Class.Abilities.Add("Ability 1");
                    character.Class.Abilities.Add("Ability 2");
                    break;

                case "Rogue":
                    character.Class.HitDice = 8;
                    character.Class.SpellSlots = 0;
                    character.Class.ProficiencyWeapons.Add("Simple Weapons");
                    character.Class.ProficiencyWeapons.Add("Longswords");
                    character.Class.ProficiencyWeapons.Add("Rapiers");
                    character.Class.ProficiencyWeapons.Add("Shortswords");
                    character.Class.ProficiencyArmour.Add("Light Armour");
                    //this is a place holder until I work out exactly what they should be
                    character.Class.Abilities.Add("Ability 1");
                    character.Class.Abilities.Add("Ability 2");
                    break;

                default:
                    return character;
            }

            character.Class.HitDiceCount = (int)Math.Ceiling((double)character.Class.Level / 3);
            Console.WriteLine(character.Class.HitDiceCount);
            return character;
        }

        public static Character AddSpeciesFeatures(Character character)
        {
            character.Species.Languages = new List<string>();


            switch (character.Species.Name)
            {
                case "Human":
                    character.Species.Size = 3;
                    character.Species.Languages.Add("Common");
                    character.Species.DarkvisionRange = 0;
                    break;

                case "Elf":
                    character.Species.Size = 3;
                    character.Species.Languages.Add("Common");
                    character.Species.Languages.Add("Elvish");
                    character.Species.DarkvisionRange = 60;
                    break;

                case "Dwarf":
                    character.Species.Size = 3;
                    character.Species.Languages.Add("Common");
                    character.Species.Languages.Add("Dwarvish");
                    character.Species.DarkvisionRange = 60;
                    break;

                default:
                    return character;
            }
            return character;
        }
    }
}
