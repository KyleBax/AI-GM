using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AI_GM.Combat;
using AI_GM.Map;

namespace AI_GM.Monsters
{
    public class Monster : GameObject, IFightable
    {


        [JsonIgnore] private Identifier _identifier = Identifier.Monster;
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

        [JsonIgnore] private int _attackDice;
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

        [JsonIgnore] private int _defendDice;
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

        [JsonIgnore] private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        [JsonIgnore] private int _speed;
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

        [JsonIgnore] private int _maxHitPoints;
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

        [JsonIgnore] private int _damageTaken;
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
        [JsonIgnore] private int _availableMovement = 0;
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
        [JsonIgnore] private int _actionsTaken = 0;
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
        [JsonIgnore] private int _maxActions = 1;
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
