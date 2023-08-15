using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM
{
    internal class Monster
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma each have a range of 0-50
        /// </summary>
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

        private int _cR;
        public int CR
        {
            get { return _cR; }
            set { _cR = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private int _speed;
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        private List<string> _attacks;
        public List<string> Attacks //TODO: attack class?
        {
            get { return _attacks; }
            set { _attacks = value; }
        }
    }
}
