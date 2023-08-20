namespace AI_GM
{
    /// <summary>
    /// Holds the information of the characters
    /// </summary>
    public class Character
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _strength;
        public int Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }

        private int _dexterity;
        public int Dexterity
        {
            get { return _dexterity; }
            set { _dexterity = value; }
        }

        private int _constitution;
        public int Constitution
        {
            get { return _constitution; }
            set { _constitution = value; }
        }

        private int _intelligence;

        public int Intelligence
        {
            get { return _intelligence; }
            set { _intelligence = value; }
        }

        private int _wisdom;
        public int Wisdom
        {
            get { return _wisdom; }
            set { _wisdom = value; }
        }

        private int _charisma;
        public int Charisma
        {
            get { return _charisma; }
            set { _charisma = value; }
        }

        private Classes _class = new Classes();
        public Classes Class
        {
            get { return _class; }
            set { _class = value; }
        }

        private Species _species = new Species();
        public Species Species
        {
            get { return _species; }
            set { _species = value; }
        }

        private int _proficeincyModifier;
        public int ProficeincyModifier
        {
            get { return _proficeincyModifier; }
            set { _proficeincyModifier = value;}
        }

        private int _level;
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        private int _speed;
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        private List<Skill> _skillsProficiencies = new List<Skill>();
        public List<Skill> SkillsProficiencies
        {
            get { return _skillsProficiencies; }
            set { _skillsProficiencies = value; }
        }


    }
}
