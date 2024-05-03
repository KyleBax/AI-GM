namespace AI_GM
{
    public interface IFightable
    {
        public int AttackDice
        {
            get; set;
        }

        public int DefendDice
        {
            get; set;
        }

        public int MaxHitPoints
        {
            get; set;
        }

        public int Speed
        {
            get; set;
        }

        public int DamageTaken
        {
            get; set;
        }

        public Identifier Identifier
        {
            get; set;
        }

        public int AvailableMovement
        {
            get; set;
        }

        public int ActionsTaken
        {
            get; set;
        }
        public int MaxActions
        {
            get; set;
        }
        public int X
        {
            get; set;
        }
        public int Y
        {
            get; set;
        }
    }
}