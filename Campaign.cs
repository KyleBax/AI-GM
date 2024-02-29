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
    public class Campaign
    {
        private List<Character> _playerCharacters = new List<Character>();
        public List<Character> PlayerCharacters
        {
            get { return _playerCharacters; }
            set { _playerCharacters = value; }
        }

        private List<Monster> _activeMonsters = new List<Monster>();
        public List<Monster> ActiveMonsters
        {
            get { return _activeMonsters; }
            set { _activeMonsters = value; }
        }

        private List<IFightable> _combatParticipants;

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

        private List<Room> _openRooms = new List<Room>();

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
    }
}
