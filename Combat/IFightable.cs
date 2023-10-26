namespace AI_GM
{
    public interface IFightable
    {
        public int AttackDice { get; set; }

        public int DefendDice { get; set; }

        public int MaxHitPoints { get; set; }

        public int StrengthModifier { get; set; }

        public int DexterityModifier { get; set; }

        public int ConstitutionModifier { get; set; }

        public int IntelligenceModifier { get; set; }

        public int WisdomModifier { get; set; }

        public int CharismaModifier { get; set; }

        public int Speed { get; set; }

        public int DamageTaken { get; set; }

        public int Initiative { get; set; }

        public Identifier Identifier { get; set; }

        public int ArmourClass { get; set; }
    }
}