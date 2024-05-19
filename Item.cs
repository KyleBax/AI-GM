using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AI_GM
{
    [Serializable()]
    public class Item
    {
        [NonSerialized()] private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [NonSerialized()] private ItemType _type;
        public ItemType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        [NonSerialized()] private ItemType _subType;
        public ItemType SubType
        {
            get { return _subType; }
            set { _subType = value; }
        }

        [NonSerialized()] private Rarity _rarity;
        public Rarity Rarity
        {
            get { return _rarity; }
            set { _rarity = value; }
        }

        [NonSerialized()] private int _cost;
        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        [NonSerialized()] private int _weight;
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        // weapon specific features
        [NonSerialized()] private int _damage;
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        [NonSerialized()] private DamageType _damageType;
        public DamageType DamageType
        {
            get { return _damageType; }
            set { _damageType = value; }
        }
    }
}
