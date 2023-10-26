using AI_GM.Characters;

namespace AI_GM
{
    internal class Logic
    {
        public static void SerializeCampaign(Campaign campaign)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Campaign));
            try
            {
                using (FileStream file = File.Create(FilePaths.SAVEDCHARACTERS))
                {
                    xmlSerializer.Serialize(file, campaign);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public static Campaign DeserializeCampaign()
        {
            Campaign campaign = new Campaign();
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Campaign));
            try
            {
                using (FileStream file = File.OpenRead(FilePaths.SAVEDCHARACTERS))
                {
                    campaign = xmlSerializer.Deserialize(file) as Campaign;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return campaign;
        }
    }
}
