using AI_GM.Characters;
using AI_GM.UserInterface;
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
            int shopSaleIncrease = 2;
            Item selectedItem = new Item();
            List<Item> instock = new List<Item>();
            Console.WriteLine();
            bool sell = UI.GetConfirmation("Would you like to sell your junk items?");
            if (sell)
            {
                int saleCost = 0;
                for (int i = 0; i < character.Inventory.Count; i++)
                {
                    saleCost += character.Inventory[i].Cost;
                }
                Console.WriteLine($"You have sold your junk for {saleCost} coins");
                character.Inventory.Clear();
                character.Coins += saleCost;
            }

            for (int i = 0; i < 5; i++)
            {
                instock.Add(Loot.GetRandomShopItem(i));
            }
            for (int i = 0; i < instock.Count; i++)
            {
                
                Console.WriteLine($"item {i + 1} Name: {instock[i].Name}, Type: {instock[i].Type}, Bonus Dice: {instock[i].ExtraDice}, Rarity: {instock[i].Rarity}, Cost: {instock[i].Cost * shopSaleIncrease}");
            }
            if (character.Coins >= 0)
            {
                Console.WriteLine($"You have {character.Coins} coins");
                Console.WriteLine("Would you like to buy anything?");
                try
                {
                    int selection = int.Parse(Console.ReadLine());

                    if (selection >= 1 && selection <= instock.Count)
                    {
                        selectedItem = instock[selection - 1];
                        if (character.Coins >= selectedItem.Cost * shopSaleIncrease)
                        {
                            character.Coins = character.Coins - selectedItem.Cost * shopSaleIncrease;
                            Console.WriteLine($"you have purchased {selectedItem.Name}");
                        }
                        else
                        {
                            Console.WriteLine("You lack coins, return when you can afford something");
                        }

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
            }
            else
            {
                Console.WriteLine("You lack coins, return when you can afford something");
            }




            return character;
        }
    }
}
