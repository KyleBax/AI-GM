using AI_GM.Combat;
using AI_GM.Items;
using AI_GM.Map;
using AI_GM.Monsters;
using System.Text.Json.Serialization;

namespace AI_GM.Characters
{
    [Serializable()]
    /// <summary>
    /// Holds the information of the characters
    /// </summary>
    public class Character : GameObject, IFightable
    {

        private int _maxHitPoints;
        public int MaxHitPoints
        {
            get
            {
                return _maxHitPoints;
            }
            set
            {
                _maxHitPoints = value;
            }
        }

        private int _damageTaken;
        public int DamageTaken
        {
            get
            {
                return _damageTaken;
            }
            set
            {
                _damageTaken = value;
            }
        }

        private Identifier _identifier = Identifier.Player;
        public Identifier Identifier
        {
            get
            {
                return _identifier;
            }
            set
            {
                _identifier = value;
            }
        }

        private int _attackDice;
        public int AttackDice
        {
            get
            {
                return _attackDice;
            }
            set
            {
                _attackDice = value;
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

        private int _playerNumber;
        public int PlayerNumber
        {
            get
            {
                return _playerNumber;
            }
            set
            {
                _playerNumber = value;
            }
        }

        private Classes _class = new Classes();
        public Classes Class
        {
            get
            {
                return _class;
            }
            set
            {
                _class = value;
            }
        }

        private Species _species = new Species();
        public Species Species
        {
            get
            {
                return _species;
            }
            set
            {
                _species = value;
            }
        }

        private int _speed;
        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        private Item _Weapon = new Item();
        public Item Weapon
        {
            get
            {
                return _Weapon;
            }
            set
            {
                _Weapon = value;
            }
        }
        private Item _Armour = new Item();
        public Item Armour
        {
            get
            {
                return _Armour;
            }
            set
            {
                _Armour = value;
            }
        }

        private List<Item> _inventory = new List<Item>();
        public List<Item> Inventory
        {
            get
            {
                return _inventory;
            }
            set
            {
                _inventory = value;
            }
        }

        private int _coins = 0;

        public int Coins
        {
            get
            {
                return _coins;
            }
            set
            {
                _coins = value;
            }
        }

        private int _availableMovement = 0;
        public int AvailableMovement
        {
            get
            {
                return _availableMovement;
            }
            set
            {
                _availableMovement = value;
            }
        }
        private int _actionsTaken = 0;
        public int ActionsTaken
        {
            get
            {
                return _actionsTaken;
            }
            set
            {
                _actionsTaken = value;
            }
        }
        private int _maxActions = 3;
        public int MaxActions
        {
            get
            {
                return _maxActions;
            }
            set
            {
                _maxActions = value;
            }
        }
    }
}
