using AI_GM.Characters;
using KGySoft.Serialization.Binary;
using KGySoft.Serialization.Xml;

namespace AI_GM
{
    internal class SaveLoad
    {
        public static void SerializeCampaign(Campaign campaign)
        {
            
            try
            {
                using (FileStream file = File.Create(FilePaths.SAVEDCAMPAIGNS))
                {
                    
                    BinarySerializationFormatter formatter = new BinarySerializationFormatter();
                    formatter.SerializeToStream(file, campaign);
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
                using (FileStream file = File.OpenRead(FilePaths.SAVEDCAMPAIGNS))
                {
                    BinarySerializationFormatter formatter = new BinarySerializationFormatter();
                    campaign = formatter.DeserializeFromStream(file) as Campaign;
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
