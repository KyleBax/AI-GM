using AI_GM.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Items
{
    internal class LootUI
    {
        public static bool EquipItem(Character character, Item item)
        {
            bool equipItem = false;
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            switch (item.Type)
            {
                case ItemType.Armour:
                    Console.WriteLine("Would you like to swap armours?");
                    Console.WriteLine($"Current {character.Armour.Name} bonus +{character.Armour.ExtraDice}");
                    Console.WriteLine($"new {item.Name} bonus +{item.ExtraDice}");
                    input = Console.ReadKey();
                    Console.WriteLine();
                    if (input.Key == ConsoleKey.Y)
                    {
                        equipItem = true;
                        Console.WriteLine($"You Have equipped {item.Name}");
                    }

                    break;
                case ItemType.Weapon:
                    Console.WriteLine("Would you like to swap weapons?");
                    Console.WriteLine($"Current {character.Weapon.Name} bonus +{character.Weapon.ExtraDice}");
                    Console.WriteLine($"new {item.Name} bonus +{item.ExtraDice}");
                    input = Console.ReadKey();
                    Console.WriteLine();
                    if (input.Key == ConsoleKey.Y)
                    {
                        equipItem = true;
                        Console.WriteLine($"You Have equipped {item.Name}");
                    }

                    break;
                default:
                    equipItem = false;
                    Console.WriteLine($"{item.Name} has been added to your inventory");
                    break;
            }
            return equipItem;
        }

        internal static void ItemFound(bool searched, string name)
        {
            if (searched == true)
            {
                Console.WriteLine($"You have found {name}");
            }
            else
            {
                Console.WriteLine($"The monster has dropped a {name}");
            }
        }
    }
}
