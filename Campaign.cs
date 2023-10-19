using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_GM.Characters;
using AI_GM.Monsters;

namespace AI_GM
{
    internal class Campaign
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
    }
}
