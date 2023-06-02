﻿namespace AI_GM
{
    internal class Species
    {
        private string _name;
        public string Name
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

        private List<string> _languages;
        public List<string> Languages
        {
            get { return _languages; }
            set { _languages = value; }
        }

        private int _darkvisionRange;
        public int DarkvisionRange
        {
            get { return _darkvisionRange; }
            set { _darkvisionRange = value; }
        }

        private string _proficiency;
        public string Prociciency
        {
            get { return _proficiency; }
            set { _proficiency = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


    }
}
