using static AI_GM.SpecieDescriptions;

namespace AI_GM
{
    public class Classes
    {
        private Class _name;
        public Class Name
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

        private List<Ability> _abilities;
        public List<Ability> Abilities
        {
            get { return _abilities; }
            set { _abilities = value; }
        }

        private List<WeaponType> _proficiencyWeapons;
        public List<WeaponType> ProficiencyWeapons
        {
            get { return _proficiencyWeapons; }
            set { _proficiencyWeapons = value; }
        }

        private List<ArmourType> _proficiencyArmour;
        public List<ArmourType> ProficiencyArmour
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
