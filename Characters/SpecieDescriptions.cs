namespace AI_GM.Characters
{
    internal class SpecieDescriptions
    {
        public static string GetDescription(Specie specieName)
        {
            string description = null;
            switch (specieName)
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
    }
}
