namespace AI_GM
{
    internal class CharacterCreation
    {
        /// <summary>
        /// runs the methods for character creation
        /// </summary>
        /// <returns></returns>
        public static Character NewCharacter()
        {
            while (true)
            {
                Character character = new Character();
                character.Name = CharacterCreationUI.GetCharacterName();
                character = CharacterCreationUI.SelectCharacterClass(character);
                character = CharacterCreationUI.SelectCharacterSpecies(character);
                character = StatPointDistribution(character);
                bool characterComplete = CharacterCreationUI.CharacterComplete(character);
                if (characterComplete)
                {
                    return character;
                }
            }
        }



        public static Character StatPointDistribution(Character character)
        {
            character.Strength = 10;
            character.Dexterity = 10;
            character.Constitution = 10;
            character.Intelligence = 10;
            character.Wisdom = 10;
            character.Charisma = 10;

            Console.WriteLine("You have 25 stat points to distribute.");
            Console.WriteLine("Current stats: Strength 10, Dexterity 10, Constitution 10, Intelligence 10, Wisdom 10, Charisma 10");
            Console.WriteLine("How would you like to distribute your points?");
            Console.WriteLine("Please enter the number of points you want to assign for each stat (separated by spaces):");

            string input = Console.ReadLine();
            string[] pointValues = input.Split(' ');

            if (pointValues.Length != 6)
            {
                Console.WriteLine("Invalid input. Please provide values for all 6 stats.");
                return StatPointDistribution(character);
            }

            int totalPoints = 25;
            int[] stats = new int[6];
            int allocatedPoints = 0;

            for (int i = 0; i < stats.Length; i++)
            {
                if (!int.TryParse(pointValues[i], out int points) || points < 0 || points > totalPoints - allocatedPoints)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number of points for each stat.");
                    return StatPointDistribution(character);
                }

                stats[i] = points;
                allocatedPoints += points;
            }

            // Assign the allocated stat points to the character
            character.Strength += stats[0];
            character.Dexterity += stats[1];
            character.Constitution += stats[2];
            character.Intelligence += stats[3];
            character.Wisdom += stats[4];
            character.Charisma += stats[5];

            Console.WriteLine("Stat points distributed successfully.");

            return character;
        }

    }
}
