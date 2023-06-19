namespace AI_GM
{
    internal class CharacterCreationUI
    {
        public static string GetCharacterName()
        {
            Console.WriteLine("Enter Character Name.");
            string name = Console.ReadLine();

            return name;
        }

        public static Character SelectCharacterClass(Character character)
        {
            List<string> classNames = NameLists.GetClassNames();
            Classes classes = new Classes();
            Console.WriteLine("select a class");
            Console.WriteLine("enter the number that corresponds to the class you would like to choose");
            while (true)
            {
                for (int i = 0; i < classNames.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + classNames[i]);
                }
                int selectedClassIndex;
                if (int.TryParse(Console.ReadLine(), out selectedClassIndex) && selectedClassIndex >= 1 && selectedClassIndex <= classNames.Count)
                {
                    classes.Name = classNames[selectedClassIndex - 1];
                    character.Class = classes;
                    Console.WriteLine("Class selected: " + classes.Name);
                    return character;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }

        }

        public static Character SelectCharacterSpecies(Character character)
        {
            List<string> speciesNames = NameLists.GetSpeciesNames();
            Species species = new Species();
            Console.WriteLine("Select a species");
            Console.WriteLine("enter the number that corresponds to the class you would like to choose");
            while (true)
            {
                for (int i = 0; i < speciesNames.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + speciesNames[i]);
                }
                int selectedSpeciesIndex;
                if (int.TryParse(Console.ReadLine(), out selectedSpeciesIndex) && selectedSpeciesIndex >= 1 && selectedSpeciesIndex <= speciesNames.Count)
                {
                    species.Name = speciesNames[selectedSpeciesIndex - 1];
                    character.Species = species;
                    Console.WriteLine("Species selected: " + species.Name);
                    return character;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }
        }

        public static bool CharacterComplete(Character character)
        {
            Console.WriteLine($"Name:{character.Name}, Class: {character.Class.Name}, Species: {character.Species.Name}");
            Console.WriteLine("Are you happy with your character? Y/N?");
            if (Console.ReadLine().ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
