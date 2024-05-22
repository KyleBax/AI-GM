using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Items
{
    internal class Loot
    {
        private static Item item = new Item();
        public static Item GetRandomItem()
        {
            item.Rarity = GetRandomEnumValue<Rarity>();
            item.Type = GetRandomEnumValue<ItemType>();
            item.Name = GetItemName();
            item.Cost = GetRandomCost();
            item.Weight = GetRandomWeight();
            item.ExtraDice = GetRandomExtraDice();
            return item;
        }

        private static int GetRandomExtraDice()
        {
            int extraDice;
            switch (item.Rarity)
            {
                case Rarity.Common:
                    extraDice = 1;
                    break;
                case Rarity.Uncommon:
                    extraDice = Dice.DiceRoll(2);
                    break;
                case Rarity.Rare:
                    extraDice = Dice.DiceRoll(2);
                    break;
                case Rarity.VeryRare:
                    extraDice = Dice.DiceRoll(3);
                    break;
                default:
                    extraDice = 0;
                    break;

            }
            return extraDice;
        }
        //TODO add weight
        private static int GetRandomWeight()
        {
            return 0;
        }

        private static int GetRandomCost()
        {
            int cost;
            switch (item.Rarity)
            {
                case Rarity.Common:
                    cost = Dice.DiceRoll(10);
                    break;
                case Rarity.Uncommon:
                    cost = Dice.DiceRoll(15) + 10;
                    break;
                case Rarity.Rare:
                    cost = Dice.DiceRoll(25) + 25;
                    break;
                case Rarity.VeryRare:
                    cost = Dice.DiceRoll(50) + 50;
                    break;
                default:
                    cost = 0;
                    break;

            }

            return cost;
        }
        private static string GetItemName()
        {
            string type;
            string enhancement;
            string name;
            switch (item.Type)
            {
                case ItemType.Armour:
                    enhancement = GetRandomName(EnhancementNames);
                    type = GetRandomName(ArmourNames);
                    name = $"{enhancement} {type}";
                    break;
                case ItemType.Weapon:
                    enhancement = GetRandomName(EnhancementNames);
                    type = GetRandomName(WeaponNames);
                    name = $"{enhancement} {type}";
                    break;
                case ItemType.Potion:
                    enhancement = GetRandomName(EnhancementNames);
                    type = GetRandomName(PotionNames);
                    name = $"{enhancement} {type}";
                    break;
                default:
                    name = "broken item name";
                    break;
            }

            return name;
        }

        private static string GetRandomName(string[] nameType)
        {
            int ranNum = Dice.DiceRoll(nameType.Length)-1;
            string name = nameType[ranNum];
            return name;
        }

        private static readonly string[] WeaponNames = new string[]
        {
            "sword","staff","stick","twig","wand","bow","dagger","spear"
        };

        private static readonly string[] ArmourNames = new string[]
        {
            "shirt","cloth","breastplate","helmet","pants","shoes","slippers","cloak"
        };

        private static readonly string[] PotionNames = new string[]
        {
            "potion"
        };

        private static readonly string[] EnhancementNames = new string[]
        {
            "flying","wicked","sticky","soggy","bright","talkative","hungry","bloodthirsty","rusty"
        };
        public static T GetRandomEnumValue<T>() where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));
            int randomNum = Dice.DiceRoll(values.Length)-1;
            return (T)values.GetValue(randomNum);
        }
    }
}
