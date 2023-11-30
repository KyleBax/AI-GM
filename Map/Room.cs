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

        private int _playerX;
        public int PlayerX
        {
            get { return _playerX; }
            set { _playerX = value; }
        }

        private int _playerY;
        public int PlayerY
        {
            get { return _playerY; }
            set { _playerY = value; }
        }

    }
}
