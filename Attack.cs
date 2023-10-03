﻿using AI_GM.Monsters;

namespace AI_GM
{
    internal class Attack
    {
        private AttackType _name;
        public AttackType Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _hitModifier;
        public int HitModifier
        {
            get { return _hitModifier; }
            set { _hitModifier = value; }
        }

        private int _damageModifier;
        public int DamageModifier
        {
            get { return _damageModifier; }
            set { _damageModifier = value; }
        }

        private string _damageDice;
        public string DamageDice
        {
            get { return _damageDice; }
            set { _damageDice = value; }
        }

        private DamageType _damageType;
        public DamageType DamageType
        {
            get { return _damageType; }
            set { _damageType = value; }
        }

    }
}
