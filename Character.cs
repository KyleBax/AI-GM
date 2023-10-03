namespace AI_GM
{
    /// <summary>
    /// Holds the information of the characters
    /// </summary>
    public class Character : IFightable
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

        private int _strengthModifier;
        public int StrengthModifier
        {
            get { return _strengthModifier; }
            set { _strengthModifier = value; }
        }

        private int _dexterity;
        public int Dexterity
        {
            get { return _dexterity; }
            set { _dexterity = value; }
        }

        private int _dexterityModifier;
        public int DexterityModifier
        {
            get { return _dexterityModifier; }
            set { _dexterityModifier = value; }
        }

        private int _constitution;
        public int Constitution
        {
            get { return _constitution; }
            set { _constitution = value; }
        }

        private int _constitutionModifier;
        public int ConstitutionModifier
        {
            get { return _constitutionModifier; }
            set { _constitutionModifier = value; }
        }

        private int _intelligence;

        public int Intelligence
        {
            get { return _intelligence; }
            set { _intelligence = value; }
        }

        private int _intelligenceModifier;
        public int IntelligenceModifier
        {
            get { return _intelligenceModifier; }
            set { _intelligenceModifier = value;}
        }

        private int _wisdom;
        public int Wisdom
        {
            get { return _wisdom; }
            set { _wisdom = value; }
        }

        private int _wisdomModifier;
        public int WisdomModifier
        {
            get { return _wisdomModifier; }
            set { _wisdomModifier = value;}
        }

        private int _charisma;
        public int Charisma
        {
            get { return _charisma; }
            set { _charisma = value; }
        }

        private int _charismaModifier;
        public int CharismaModifier
        {
            get { return _charismaModifier; }
            set { _charismaModifier = value;}
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

        private List<Item> _inventory = new List<Item> ();
        public List<Item> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        private int _initiative;
        public int Initiative
        {
            get { return _initiative; }
            set { _initiative = value; }
        }

        private int _maxHitPoints;
        public int MaxHitPoints
        {
            get { return _maxHitPoints; }
            set { _maxHitPoints = value; }
        }

        private int _damageTaken;
        public int DamageTaken
        {
            get { return _damageTaken; }
            set { _damageTaken = value; }
        }

        private Identifier _identifier = Identifier.Player;
        public Identifier Identifier
        {
            get { return _identifier; }
            set { _identifier = value; }
        }

    }
}
