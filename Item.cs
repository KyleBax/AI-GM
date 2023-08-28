using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM
{
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

        private ItemType _subType;
        public ItemType SubType
        {
            get { return _subType; }
            set { _subType = value; }
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

        // weapon specific features
        private int _damage;
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        private DamageType _damageType;
        public DamageType DamageType
        {
            get { return _damageType; }
            set { _damageType = value; }
        }

        //armor specific features
        private int _aCBase;
        public int ACBase
        {
            get { return _aCBase; }
            set { _aCBase = value; }
        }

        private int _dexBonusMax;
        public int DexBonusMax
        {
            get { return _dexBonusMax; }
            set { _dexBonusMax = value; }
        }

        private List<Property> _properties;
        public List<Property> Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }
    }
}
