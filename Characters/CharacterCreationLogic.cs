namespace AI_GM.Characters
{
    internal class CharacterCreationLogic
    {
        public static Character AddClassFeatures(Character character)
        {

            switch (character.Class.Name)
            {
                case Class.Cleric:
                    character.AttackDice = 2;
                    character.DefendDice = 2;
                    character.MaxHitPoints = 4;

                    character.Class.HitDice = 8;
                    character.Class.SpellSlots = 3;
                    character.Class.ProficiencyWeapons.Add(WeaponType.Simple);
                    character.Class.ProficiencyArmour.Add(Armour.Light);
                    character.Class.ProficiencyArmour.Add(Armour.Medium);
                    //this is a place holder until I work out exactly what they should be
                    character.Class.Abilities.Add(Ability.Ability1);
                    character.Class.Abilities.Add(Ability.Ability2);
                    break;

                case Class.Fighter:
                    character.AttackDice = 2;
                    character.DefendDice = 3;
                    character.MaxHitPoints = 8;

                    character.Class.HitDice = 10;
                    character.Class.SpellSlots = 0;
                    character.Class.ProficiencyWeapons.Add(WeaponType.Simple);
                    character.Class.ProficiencyWeapons.Add(WeaponType.Martial);
                    character.Class.ProficiencyArmour.Add(Armour.Light);
                    character.Class.ProficiencyArmour.Add(Armour.Medium);
                    character.Class.ProficiencyArmour.Add(Armour.Heavy);
                    //this is a place holder until I work out exactly what they should be
                    character.Class.Abilities.Add(Ability.Ability3);
                    character.Class.Abilities.Add(Ability.Ability4);
                    break;

                case Class.Wizard:
                    character.AttackDice = 1;
                    character.DefendDice = 1;
                    character.MaxHitPoints = 4;

                    character.Class.HitDice = 6;
                    character.Class.SpellSlots = 3;
                    character.Class.ProficiencyWeapons.Add(WeaponType.Daggers);
                    character.Class.ProficiencyWeapons.Add(WeaponType.Darts);
                    character.Class.ProficiencyWeapons.Add(WeaponType.QuarterStaffs);
                    character.Class.ProficiencyArmour.Add(Armour.Light);
                    //this is a place holder until I work out exactly what they should be
                    character.Class.Abilities.Add(Ability.Ability5);
                    character.Class.Abilities.Add(Ability.Ability6);
                    break;

                case Class.Rogue:
                    character.AttackDice = 1;
                    character.DefendDice = 2;
                    character.MaxHitPoints = 6;

                    character.Class.HitDice = 8;
                    character.Class.SpellSlots = 0;
                    character.Class.ProficiencyWeapons.Add(WeaponType.Simple);
                    character.Class.ProficiencyWeapons.Add(WeaponType.LongSwords);
                    character.Class.ProficiencyWeapons.Add(WeaponType.Rapiers);
                    character.Class.ProficiencyWeapons.Add(WeaponType.ShortSwords);
                    character.Class.ProficiencyArmour.Add(Armour.Light);
                    //this is a place holder until I work out exactly what they should be
                    character.Class.Abilities.Add(Ability.Ability7);
                    character.Class.Abilities.Add(Ability.Ability8);
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
            switch (character.Species.Name)
            {
                case Specie.Human:
                    character.Species.Size = 3;
                    character.Species.Languages.Add(Language.Common);
                    character.Species.DarkvisionRange = 0;
                    character.Species.Cauterize = true;
                    character.Species.StrongMind = true;
                    character.Species.Description = SpecieDescriptions.GetDescription(Specie.Human);
                    break;

                case Specie.Elf:
                    character.Species.Size = 3;
                    character.Species.Languages.Add(Language.Common);
                    character.Species.Languages.Add(Language.Elvish);
                    character.Species.DarkvisionRange = 60;
                    character.Species.Cauterize = false;
                    character.Species.StrongMind = true;
                    character.Species.Description = SpecieDescriptions.GetDescription(Specie.Elf);
                    break;

                case Specie.Dwarf:
                    character.Species.Size = 3;
                    character.Species.Languages.Add(Language.Common);
                    character.Species.Languages.Add(Language.Dwarvish);
                    character.Species.DarkvisionRange = 60;
                    character.Species.Cauterize = true;
                    character.Species.StrongMind = false;
                    character.Species.Description = SpecieDescriptions.GetDescription(Specie.Dwarf);
                    break;

                default:
                    return character;
            }
            return character;
        }

        public static Character StatModifiers(Character character)
        {
            character.StrengthModifier = CalculateModifier(character.Strength);
            character.DexterityModifier = CalculateModifier(character.Dexterity);
            character.ConstitutionModifier = CalculateModifier(character.Constitution);
            character.IntelligenceModifier = CalculateModifier(character.Intelligence);
            character.WisdomModifier = CalculateModifier(character.Wisdom);
            character.CharismaModifier = CalculateModifier(character.Charisma);
            return character;
        }

        public static int CalculateModifier(int statValue)
        {
            return (statValue - 10) / 2;
        }

        public static int CalulateStartingHitPoints(Character character)
        {
            int hitPoints = character.Class.HitDice + character.ConstitutionModifier;
            return hitPoints;
        }

    }
}
