using AI_GM.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace AI_GM.Map
{
    public class Room
    {
        // Key for rooms
        // # == Wall
        // D == Door
        // m == Monster
        // C == Chest
        // T == Trap
        // S == Spawn Point
        // E == Exit/Next Floor

        private char[,] _layout;
        public char[,] Layout
        {
            get
            {
                return _layout;
            }
            set
            {
                _layout = value;
            }
        }

        public List<IFightable> PresentPlayers = new();
    }
}
