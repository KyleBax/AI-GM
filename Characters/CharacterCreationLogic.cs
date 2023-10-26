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
                    break;

                case Class.Fighter:
                    character.AttackDice = 2;
                    character.DefendDice = 3;
                    character.MaxHitPoints = 8;
                    break;

                case Class.Wizard:
                    character.AttackDice = 1;
                    character.DefendDice = 1;
                    character.MaxHitPoints = 4;
                    break;

                case Class.Rogue:
                    character.AttackDice = 1;
                    character.DefendDice = 2;
                    character.MaxHitPoints = 6;
                    break;

                default:
                    return character;
            }
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
    }
}
