using AI_GM.Characters;
using AI_GM.Items;
using AI_GM.Map;
using AI_GM.Monsters;
using KGySoft.Serialization.Binary;
using System;
using System.Collections.Generic;
using System.IO;

namespace AI_GM
{
    internal static class SaveLoad
    {
        public static void SerializeCampaign(Campaign campaign)
        {

                using (FileStream file = File.Create(FilePaths.SAVEDCAMPAIGNS))
                {
                    var formatter = new BinarySerializationFormatter();
                    formatter.SerializeToStream(file, campaign);
                }
        }
        public static Campaign DeserializeCampaign()
        {
            Campaign campaign = new Campaign();
            using (FileStream file = File.OpenRead(FilePaths.SAVEDCAMPAIGNS))
            {
                var formatter = new BinarySerializationFormatter();
                // Add the expected custom types here
                Type[] customTypes = {
                    typeof(Campaign),
                    typeof(Character),
                    typeof(Identifier),
                    typeof(Classes),
                    typeof(Species),
                    typeof(Item),
                    typeof(Monster),
                    typeof(IFightable),
                    typeof(Room)
                };
                 campaign = formatter.DeserializeFromStream<Campaign>(file, customTypes);
            }
            return campaign;
        }
    }
}
