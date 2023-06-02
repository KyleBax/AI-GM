namespace AI_GM
{
    internal class Classes
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

        private List<string> _proficiencies;
        public List<string> Proficiencies
        {
            get { return _proficiencies; }
            set { _proficiencies = value; }
        }

        private List<string> _proficiencyWeapons;
        public List<string> ProficiencyWeapons
        {
            get { return _proficiencyWeapons; }
            set { _proficiencyWeapons = value; }
        }
    }
}
