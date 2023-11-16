using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Map
{
    internal class Room
    {
        private char[,] _layout;
        public char[,] layout
        {
            get { return _layout; }
            set { _layout = value; }
        }
    }
}
