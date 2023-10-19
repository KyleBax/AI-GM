namespace AI_GM.Characters
{
    public class Species
    {
        private Specie _name;
        public Specie Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _size;
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        private List<Language> _languages = new List<Language>();
        public List<Language> Languages
        {
            get { return _languages; }
            set { _languages = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private int _darkvisionRange;
        public int DarkvisionRange
        {
            get { return _darkvisionRange; }
            set { _darkvisionRange = value; }
        }

        private bool _cauterize;
        public bool Cauterize
        {
            get { return _cauterize; }
            set { _cauterize = value; }
        }

        private bool _strongMind;
        public bool StrongMind
        {
            get { return _strongMind; }
            set { _strongMind = value; }
        }


    }
}
