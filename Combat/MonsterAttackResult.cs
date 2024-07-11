using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Combat
{
    internal class MonsterAttackResult
    {
        private string _monsterName;
        public string MonsterName
        {
            get
            {
                return _monsterName;
            }
            set
            {
                _monsterName = value;
            }
        }

        private bool _missed;
        public bool Missed
        {
            get
            {
                return _missed;
            }
            set
            {
                _missed = value;
            }
        }

        private int _hits;
        public int Hits
        {
            get
            {
                return _hits;
            }
            set
            {
                _hits = value;
            }
        }

        private int _defendDice;
        public int DefendDice
        {
            get
            {
                return _defendDice;
            }
            set
            {
                _defendDice = value;
            }
        }

        private int _damage;
        public int Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                _damage = value;
            }
        }

        private int _healthRamaining;
        public int HealthRemaining
        {
            get
            {
                return _healthRamaining;
            }
            set
            {
                _healthRamaining = value;
            }
        }
    }
}
