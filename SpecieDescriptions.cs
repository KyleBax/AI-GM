namespace AI_GM
{
    internal class SpecieDescriptions
    {
        public static string GetDescription(Character character)
        {
            string description = null;
            switch (character.Species.Name)
            {
                case Specie.Human:
                    description = "generic human description here";
                    break;
                case Specie.Dwarf:
                    description = "generic dwarf description here";
                    break;
                case Specie.Elf:
                    description = "generic elf description here";
                    break;
            }
            return description;
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
