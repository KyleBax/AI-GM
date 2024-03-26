using AI_GM.Characters;
using KGySoft.Serialization.Binary;
using KGySoft.Serialization.Xml;

namespace AI_GM
{
    internal class Logic
    {
        public static void SerializeCampaign(Campaign campaign)
        {
            
            try
            {
                //System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Campaign));
                using (FileStream file = File.Create(FilePaths.SAVEDCHARACTERS))
                {
                    
                    BinarySerializationFormatter formatter = new BinarySerializationFormatter();
                    formatter.SerializeToStream(file, campaign);
                  //  xmlSerializer.Serialize(file, campaign);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception);
            }
        }

        public static Campaign DeserializeCampaign()
        {
            Campaign campaign = new Campaign();
            
            try
            {
                //System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Campaign));
                using (FileStream file = File.OpenRead(FilePaths.SAVEDCHARACTERS))
                {
                    BinarySerializationFormatter formatter = new();
                    campaign = formatter.DeserializeFromStream(file) as Campaign;
                    // campaign = xmlSerializer.Deserialize(file) as Campaign;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception);
            }
            return campaign;
        }
    }
}
