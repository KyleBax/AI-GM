using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_GM.Characters;
using AI_GM.Map;
using AI_GM.Monsters;

namespace AI_GM
{
    [Serializable()]
    public class Campaign
    {
        private List<Character> _playerCharacters = new List<Character>();
        public List<Character> PlayerCharacters
        {
            get { return _playerCharacters; }
            set { _playerCharacters = value; }
        }

        [NonSerialized()] private List<Monster> _activeMonsters = new List<Monster>();
        public List<Monster> ActiveMonsters
        {
            get { return _activeMonsters; }
            set { _activeMonsters = value; }
        }

        [NonSerialized()] private List<IFightable> _combatParticipants = new List<IFightable>();

        public List<IFightable> CombatParticipants
        {
            get
            {
                return _combatParticipants;
            }
            set
            {
                _combatParticipants = value;
            }
        }


        private int _playerCount = 1;
        public int PlayerCount
        {
            get { return _playerCount; }
            set { _playerCount = value; }
        }

        private int _activePlayer = 0;
        public int ActivePlayer
        {
            get { return _activePlayer; }
            set { _activePlayer = value; }
        }

        [NonSerialized()] private List<Room> _openRooms = new List<Room>();

        public List<Room> OpenRooms
        {
            get
            {
                return _openRooms;
            }
            set
            {
                _openRooms = value;
            }
        }

        public void OnDeserialization(object sender)
        {
            // Ensure lists are initialized after deserialization
            if (_playerCharacters == null)
                _playerCharacters = new List<Character>();

            if (_activeMonsters == null)
                _activeMonsters = new List<Monster>();

            if (_openRooms == null)
                _openRooms = new List<Room>();

            // Any other initialization can be done here
        }
    }
}
