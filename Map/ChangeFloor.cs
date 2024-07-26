using AI_GM.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Map
{
    internal class ChangeFloor
    {
        private bool _leaveFloor = false;
        public bool LeaveFloor
        {
            get
            {
                return _leaveFloor;
            }
            set
            {
                _leaveFloor = value;
            }
        }

        private bool _nextFloor = false;
        public bool NextFloor
        {
            get
            {
                return _nextFloor;
            }
            set
            {
                _nextFloor = value;
            }
        }

        private bool _leaveDungeon = false;
        public bool LeaveDungeon
        {
            get
            {
                return _leaveDungeon;
            }
            set
            {
                _leaveDungeon = value;
            }
        }
    }
}
