﻿namespace AI_GM
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
                case Class.Cleric:
                    character.Class.HitDice = 8;
                    character.Class.SpellSlots = 3;
                    character.Class.ProficiencyWeapons.Add(WeaponType.SimpleWeapons);
                    character.Class.ProficiencyArmour.Add(ArmourType.LightArmour);
                    character.Class.ProficiencyArmour.Add(ArmourType.MediumArmour);
                    //this is a place holder until I work out exactly what they should be
                    character.Class.Abilities.Add(Ability.Ability1);
                    character.Class.Abilities.Add(Ability.Ability2);
                    break;

                case  Class.Fighter:
                    character.Class.HitDice = 10;
                    character.Class.SpellSlots = 0;
                    character.Class.ProficiencyWeapons.Add(WeaponType.SimpleWeapons);
                    character.Class.ProficiencyWeapons.Add(WeaponType.MartialWeapons);
                    character.Class.ProficiencyArmour.Add(ArmourType.LightArmour);
                    character.Class.ProficiencyArmour.Add(ArmourType.MediumArmour);
                    character.Class.ProficiencyArmour.Add(ArmourType.HeavyArmour);
                    //this is a place holder until I work out exactly what they should be
                    character.Class.Abilities.Add(Ability.Ability3);
                    character.Class.Abilities.Add(Ability.Ability4);
                    break;

                case Class.Wizard:
                    character.Class.HitDice = 6;
                    character.Class.SpellSlots = 3;
                    character.Class.ProficiencyWeapons.Add(WeaponType.Daggers);
                    character.Class.ProficiencyWeapons.Add(WeaponType.Darts);
                    character.Class.ProficiencyWeapons.Add(WeaponType.QuarterStaffs);
                    character.Class.ProficiencyArmour.Add(ArmourType.LightArmour);
                    //this is a place holder until I work out exactly what they should be
                    character.Class.Abilities.Add(Ability.Ability5);
                    character.Class.Abilities.Add(Ability.Ability6);
                    break;

                case Class.Rogue:
                    character.Class.HitDice = 8;
                    character.Class.SpellSlots = 0;
                    character.Class.ProficiencyWeapons.Add(WeaponType.SimpleWeapons);
                    character.Class.ProficiencyWeapons.Add(WeaponType.LongSwords);
                    character.Class.ProficiencyWeapons.Add(WeaponType.Rapiers);
                    character.Class.ProficiencyWeapons.Add(WeaponType.ShortSwords);
                    character.Class.ProficiencyArmour.Add(ArmourType.LightArmour);
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
            character.Species.Languages = new List<Language>();


            switch (character.Species.Name)
            {
                case Specie.Human:
                    character.Species.Size = 3;
                    character.Species.Languages.Add(Language.Common);
                    character.Species.DarkvisionRange = 0;
                    character.Species.Cauterize = true;
                    character.Species.StrongMind = true;
                    character.Species.Description = SpecieDescriptions.HumanDescription();
                    break;

                case Specie.Elf:
                    character.Species.Size = 3;
                    character.Species.Languages.Add(Language.Common);
                    character.Species.Languages.Add(Language.Elvish);
                    character.Species.DarkvisionRange = 60;
                    character.Species.Cauterize = false;
                    character.Species.StrongMind = true; 
                    character.Species.Description = SpecieDescriptions.ElfDescription();
                    break;

                case Specie.Dwarf:
                    character.Species.Size = 3;
                    character.Species.Languages.Add(Language.Common);
                    character.Species.Languages.Add(Language.Dwarvish);
                    character.Species.DarkvisionRange = 60;
                    character.Species.Cauterize = true;
                    character.Species.StrongMind = false;
                    character.Species.Description = SpecieDescriptions.DwarfDescription();
                    break;

                default:
                    return character;
            }
            return character;
        }
    }
}
