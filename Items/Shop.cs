using AI_GM.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Items
{
    internal class Shop
    {
        public static Character EnterShop(Character character)
        {
            Item selectedItem = new Item();
            List<Item> instock = new List<Item>();
            for (int i = 0; i < 5; i++)
            {
                instock.Add(Loot.GetRandomShopItem(i));
            }
            for (int i = 0; i < instock.Count; i++)
            {
            Console.WriteLine($"item {i} Name: {instock[i].Name}, Type: {instock[i].Type}, Bonus Dice: {instock[i].ExtraDice}, Rarity: {instock[i].Rarity}, Cost: {instock[i].Cost *2}");
            }
            Console.WriteLine($"You have {character.Coins} coins");
            Console.WriteLine("Would you like to buy anything?");
            try
            {
                int selection = int.Parse(Console.ReadLine());

                if (selection >= 1 && selection <= instock.Count)
                {
                    selectedItem = instock[selection - 1];
                }
                else
                {
                    Console.WriteLine("Invalid Selection");
                    Console.WriteLine("Select one of these options");
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid number");
            }

            

            return character;
        }
    }
}
