namespace AI_GM
{
    internal class Logic
    {
        public static void SerializeCharacter(Character character)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Character));
            try
            {
                using (FileStream file = File.Create(SavePath.SAVEDCHARACTERS))
                {
                    xmlSerializer.Serialize(file, character);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public static Character DeserializeCharacter()
        {
            Character character = new Character();
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Character));
            try
            {
                using (FileStream file = File.OpenRead(SavePath.SAVEDCHARACTERS))
                {
                    character = xmlSerializer.Deserialize(file) as Character;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return character;
        }
    }
}
