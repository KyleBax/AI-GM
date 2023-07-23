namespace AI_GM
{
    internal class NameLists
    {
        public static List<string> GetClassNames()
        {
            List<string> classNames = new List<string>();

            classNames.Add("Cleric");
            classNames.Add("Fighter");
            classNames.Add("Wizard");
            classNames.Add("Rogue");

            return classNames;
        }

        public static List<string> GetSpeciesNames()
        {
            List<string> speciesNames = new List<string>();

            speciesNames.Add("Human");
            speciesNames.Add("Elf");
            speciesNames.Add("Dwarf");

            return speciesNames;
        }

        public static List<string> GetSpellNames()
        {
            List<string> spellNames = new List<string>();

            spellNames.Add("Cure Wounds");
            spellNames.Add("Firebolt");
            spellNames.Add("Bless");

            return spellNames;
        }

        public static List<string> GetClericProficiencies()
        {
            List<string> clericProficiencies = new List<string>();

            clericProficiencies.Add("Survival");
            clericProficiencies.Add("Religion");
            clericProficiencies.Add("Medicine");
            clericProficiencies.Add("Perception");
            clericProficiencies.Add("Persuasion");
            clericProficiencies.Add("History");

            return clericProficiencies;
        }

        public static List<string> GetFighterProficiencies()
        {
            List<string> fighterProficiencies = new List<string>();

            fighterProficiencies.Add("Acrobatics");
            fighterProficiencies.Add("Athletics");
            fighterProficiencies.Add("Insight");
            fighterProficiencies.Add("Perception");
            fighterProficiencies.Add("Survival");
            fighterProficiencies.Add("History");

            return fighterProficiencies;
        }

        public static List<string> GetWizardProficiencies()
        {
            List<string> wizardProficiencies = new List<string>();

            wizardProficiencies.Add("Insight");
            wizardProficiencies.Add("Arcana");
            wizardProficiencies.Add("Medicine");
            wizardProficiencies.Add("Insight");
            wizardProficiencies.Add("Investigation");
            wizardProficiencies.Add("History");

            return wizardProficiencies;
        }

        public static List<string> GetRogueProficiencies()
        {
            List<string> rogueProficiencies = new List<string>();

            rogueProficiencies.Add("Stealth");
            rogueProficiencies.Add("Sleight of Hand");
            rogueProficiencies.Add("Acrobatics");
            rogueProficiencies.Add("Perception");
            rogueProficiencies.Add("Persuasion");
            rogueProficiencies.Add("Deception");

            return rogueProficiencies;
        }


        public static List<string> GetOptionalElvenLanguages()
        {
            List<string> elvenLanguages = new List<string>();

            elvenLanguages.Add("Dwarvish");
            elvenLanguages.Add("Giant");
            return elvenLanguages;
        }

        public static List<string> GetOptionalDwarvenLanguages()
        {
            List<string> dwarvenLanguages = new List<string>();

            dwarvenLanguages.Add("Elvish");
            dwarvenLanguages.Add("Giant");
            return dwarvenLanguages;
        }

        public static List<string> GetOptionalHumanLanguages()
        {
            List<string> humanLanguages = new List<string>();

            humanLanguages.Add("Elvish");
            humanLanguages.Add("Dwarvish");
            humanLanguages.Add("Giant");
            return humanLanguages;
        }

        public static string HumanDescription()
        {
            return "insert description here";
        }

        public static string ElfDescription()
        {
            return "insert description here";
        }

        public static string DwarfDescription()
        {
            return "insert description here";
        }


    }
}
