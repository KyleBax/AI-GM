using AI_GM.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Map
{
    public class PlayerAction
    {
        private Campaign _campaign = new Campaign();
        public Campaign Campaign
        {
            get
            {
                return _campaign;
            }
            set
            {
                _campaign = value;
            }
        }

        private string _output;
        public string Output
        {
            get
            {
                return _output;
            }
            set
            {
                _output = value;
            }
        }
    }
}
