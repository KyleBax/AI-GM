using AI_GM.Combat;
using AI_GM.Map;

namespace AI_GM.Characters
{
    /// <summary>
    /// Holds the information of the characters
    /// </summary>
    public class Character : GameObject, IFightable
    {

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

        private int _attackDice;
        public int AttackDice
        {
            get { return _attackDice; }
            set { _attackDice = value; }
        }

        private int _defendDice;
        public int DefendDice
        {
            get { return _defendDice; }
            set { _defendDice = value; }
        }

        private int _playerNumber;
        public int PlayerNumber
        {
            get { return _playerNumber; }
            set { _playerNumber = value; }
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
            set { _proficeincyModifier = value; }
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

        private List<Item> _inventory = new List<Item>();
        public List<Item> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

    }
}
