using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Map
{
    public class GameObject
    {
        // Key for rooms
        // # == Wall
        // D == Door
        // m == Monster, will be replaced with a letter to signify the type of monster that spawns
        // C == Chest
        // T == Trap
        // S == Spawn Point, is replaced by the player letter

        private string _name;

		public string Name 
		{
			get { return _name; }
			set { _name = value; }
		}

		private char _mapChar;

		public char MapChar
		{
			get { return _mapChar; }
			set { _mapChar = value; }
		}

		private int _x;
		public int X
		{
			get { return _x; }
			set { _x = value; }
		}

		private int _y;
		public int Y
		{
			get { return _y; }
			set { _y = value; }
		}


	}
}
