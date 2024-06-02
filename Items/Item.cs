using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AI_GM.Items
{
    [Serializable()]
    public class Item
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        private ItemType _type;
        public ItemType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private Rarity _rarity;
        public Rarity Rarity
        {
            get { return _rarity; }
            set { _rarity = value; }
        }

        private int _cost;
        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        private int _weight;
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        
        private int _extraDice;
        public int ExtraDice
        {
            get { return _extraDice; }
            set { _extraDice = value; }
        }

        // weapon specific features
        private DamageType _damageType;
        public DamageType DamageType
        {
            get { return _damageType; }
            set { _damageType = value; }
        }
        private int _attackRange;
        public int AttackRange
        {
            get
            {
                return _attackRange;
            }
            set
            {
                _attackRange = value;
            }
        }
        private WeaponName _weaponNameType;
        public WeaponName WeaponNameType
        {
            get
            {
                return _weaponNameType;
            }
            set
            {
                _weaponNameType = value;
            }
        }
    }
}
