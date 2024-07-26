using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Map
{
    public enum BlockedBy
    {
        None,
        Monster,
        Chest,
        Wall,
        Trap,
        Movement,
        Door,
        NewFloor,
        Shop
    }
}
