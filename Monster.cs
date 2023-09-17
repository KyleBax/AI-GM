﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM
{
    internal class Monster
    {
        private MonsterName _name;

        public MonsterName Name
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
            set { _intelligenceModifier = value; }
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
            set { _wisdomModifier = value; }
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
            set { _charismaModifier = value; }
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

        private List<Attack> _attacks;
        public List<Attack> Attacks //TODO: attack class? (attack has some properties like damage value, range, name etc
        {
            get { return _attacks; }
            set { _attacks = value; }
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

        private int _initiative;
        public int Initiative
        {
            get { return _initiative; }
            set { _initiative = value; }
        }


    }
}
