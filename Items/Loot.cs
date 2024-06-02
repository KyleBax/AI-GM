using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Items
{
    internal class Loot
    {
        public static Item item = new Item();

        public static Item GetStartingEquipment(bool weapon)
        {
            item = new Item();
            item.Rarity = Rarity.Common;
            item.Cost = 0;
            item.Weight = 0;
            item.ExtraDice = 0;
            if (weapon)
            {
                item.Type = ItemType.Weapon;
                item.Name = "Beginner stick";
            }
            else
            {
                item.Type = ItemType.Armour;
                item.Name = "Beginner shirt";
            }

            return item;
        }

        public static Campaign AddNewItem(Campaign campaign, int i, bool searched)
        {
            item = new Item();
            GetRandomItem();

            if (searched == true)
            {
                Console.WriteLine($"You have found {item.Name}");
            }
            else
            {
                Console.WriteLine($"The monster has dropped a {item.Name}");
            }
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            //TODO make a method for what happens in the cases as they are extrememly similar
            switch (item.Type)
            {
                case ItemType.Armour:
                    Console.WriteLine("Would you like to swap armours?");
                    Console.WriteLine($"Current {campaign.PlayerCharacters[i].Armour.Name} bonus +{campaign.PlayerCharacters[i].Armour.ExtraDice}");
                    Console.WriteLine($"new {item.Name} bonus +{item.ExtraDice}");
                    input = Console.ReadKey();
                    Console.WriteLine();
                    if (input.Key == ConsoleKey.Y)
                    {
                        campaign.PlayerCharacters[i].Armour = item;
                        Console.WriteLine($"You Have equipped {item.Name}");
                    }

                    break;
                case ItemType.Weapon:
                    Console.WriteLine("Would you like to swap weapons?");
                    Console.WriteLine($"Current {campaign.PlayerCharacters[i].Weapon.Name} bonus +{campaign.PlayerCharacters[i].Weapon.ExtraDice}");
                    Console.WriteLine($"new {item.Name} bonus +{item.ExtraDice}");
                    input = Console.ReadKey();
                    Console.WriteLine();
                    if (input.Key == ConsoleKey.Y)
                    {
                        campaign.PlayerCharacters[i].Weapon = item;
                        Console.WriteLine($"You Have equipped {item.Name}");
                    }

                    break;
                default:
                    campaign.PlayerCharacters[i].Inventory.Add(item);
                    Console.WriteLine($"{item.Name} has been added to your inventory");
                    break;
            }
            return campaign;
        }

        public static void GetRandomItem()
        {
            item.Rarity = GetRandomEnumValue<Rarity>(true);
            item.Type = GetRandomEnumValue<ItemType>(false);
            item.Name = GetItemName();
            item.Cost = GetRandomCost();
            item.Weight = GetRandomWeight();
            item.ExtraDice = GetRandomExtraDice();
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
                case Rarity.Epic:
                    extraDice = Dice.DiceRoll(4);
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
                    cost = Dice.DiceRoll(5);
                    break;
                case Rarity.Uncommon:
                    cost = Dice.DiceRoll(10) + 5;
                    break;
                case Rarity.Rare:
                    cost = Dice.DiceRoll(15) + 15;
                    break;
                case Rarity.VeryRare:
                    cost = Dice.DiceRoll(20) + 30;
                    break;
                    case Rarity.Epic:
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
                case ItemType.Junk:
                    enhancement = GetRandomName(EnhancementNames);
                    type = GetRandomName(JunkNames);
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
            int ranNum = Dice.DiceRoll(nameType.Length) - 1;
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

        private static readonly string[] JunkNames = new string[]
        {
            "potion","scrap","trash","vial","bag","flask"
        };

        private static readonly string[] EnhancementNames = new string[]
        {
            "flying","wicked","sticky","soggy","bright","talkative","hungry","bloodthirsty","rusty"
        };
        public static T GetRandomEnumValue<T>(bool rarity) where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));
            int randomNum = Dice.DiceRoll(values.Length) - 1;
            if (rarity)
            {
                int[] chances = GetChances<T>();
                int chance = chances.Sum();
                for (int i = 0; i < values.Length; i++)
                {
                    if (randomNum < chances[i])
                    {
                        return (T)values.GetValue(i);
                    }
                    randomNum -= chances[i];
                }
            }
            return (T)values.GetValue(randomNum);
        }

        private static int[] GetChances<T>()
        {
            return typeof(T).GetEnumValues().Cast<T>().Select(value =>
            {
                switch (value)
                {
                    case Rarity.Common:
                        return 50;  // Common is more likely
                    case Rarity.Uncommon:
                        return 30;
                    case Rarity.Rare:
                        return 15;
                    case Rarity.VeryRare:
                        return 5;
                    case Rarity.Epic:
                        return 0;
                    // Legendary is less likely
                    default:
                        return 1;   // Default chance
                }
            }).ToArray();
        }

        internal static Item GetRandomShopItem(int i)
        {
            switch (i)
            {
                case 0:
                    item.Rarity = Rarity.Common;
                    break;
                case 1:
                    item.Rarity = Rarity.Uncommon;
                    break;
                case 2:
                    item.Rarity = Rarity.Rare;
                    break;
                case 3:
                    item.Rarity = Rarity.VeryRare;
                    break;
                case 4:
                    item.Rarity = Rarity.Epic;
                    break;
                default:
                    break;
            }
            while (true)
            {
                item.Type = GetRandomEnumValue<ItemType>(false);
                if (item.Type != ItemType.Junk)
                {
                    break;
                }
            }          
            item.Cost = GetRandomCost();
            item.Weight = GetRandomWeight();
            item.ExtraDice = GetRandomExtraDice();
            item.Name = GetItemName();
            return item;
        }
    }
}
