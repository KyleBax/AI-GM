using System.Text.Json.Serialization;

namespace AI_GM.Characters
{
    [Serializable()]
    public class Classes
    {
        [NonSerialized]  private Class _name;
        public Class Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [NonSerialized] private int _level = 1;
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

    }
}
