using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Map
{
    internal class Room
    {
        // Key for rooms
        // # == Wall
        // D == Door
        // m == Monster
        // C == Chest
        // T == Trap
        // S == Spawn Point

        private char[,] _layout;
        public char[,] Layout
        {
            get { return _layout; }
            set { _layout = value; }
        }

        private int _remainingMoves;
        public int RemainingMoves
        {
            get { return _remainingMoves; }
            set { _remainingMoves = value; }
        }
    }
}
