namespace AI_GM
{
    public class Classes
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _spellSlots;
        public int SpellSlots
        {
            get { return _spellSlots; }
            set { _spellSlots = value; }
        }

        private List<string> _abilities;
        public List<string> Abilities
        {
            get { return _abilities; }
            set { _abilities = value; }
        }

        private string _skillProficiency1;
        public string SkillProficiency1
        {
            get { return _skillProficiency1; }
            set { _skillProficiency1 = value; }
        }

        private string _skillProficiency2;
        public string SkillProficiency2
        {
            get { return _skillProficiency2; }
            set { _skillProficiency2 = value; }
        }

        private string _skillProficiency3;
        public string SkillProficiency3
        {
            get { return _skillProficiency3; }
            set { _skillProficiency3 = value; }
        }

        private List<string> _proficiencyWeapons;
        public List<string> ProficiencyWeapons
        {
            get { return _proficiencyWeapons; }
            set { _proficiencyWeapons = value; }
        }

        private List<string> _proficiencyArmour;
        public List<string> ProficiencyArmour
        {
            get { return _proficiencyArmour; }
            set { _proficiencyArmour = value; }
        }

        private int _hitDice;
        public int HitDice
        {
            get { return _hitDice; }
            set { _hitDice = value; }
        }

        private int _hitDiceCount;
        public int HitDiceCount
        {
            get { return _hitDiceCount; }
            set { _hitDiceCount = value; }
        }

        private int _level;
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
    }
}
