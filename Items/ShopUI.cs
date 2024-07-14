using AI_GM.Characters;
using AI_GM.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Items
{
    internal class ShopUI
    {
         public static bool EnterShop()
        {
            Console.WriteLine();
            bool sell = UI.GetConfirmation("Would you like to sell your junk items?");
            return sell;
        }

        public static void SoldItems(int saleCost)
        {
            Console.WriteLine($"You have sold your junk for {saleCost} coins");
        }

        internal static void CoinCheck(int coins, bool gotCoin)
        {
            if (gotCoin)
            {
                Console.WriteLine($"You have {coins} coins");
                Console.WriteLine("Would you like to buy anything?");
            }
            else
            {
                Console.WriteLine("You lack coins, return when you can afford something");
            }
        }

        internal static void InvalidSelection()
        {
            Console.WriteLine("Invalid Selection");
            Console.WriteLine("Select one of these options");
        }

        internal static void PrintShopItems(List<Item> instock, int shopSaleIncrease)
        {
            for (int i = 0; i < instock.Count; i++)
            {

                Console.WriteLine($"item {i + 1} Name: {instock[i].Name}, Type: {instock[i].Type}, Bonus Dice: {instock[i].ExtraDice}, Rarity: {instock[i].Rarity}, Cost: {instock[i].Cost * shopSaleIncrease}");
            }
        }

        internal static void PurchaseShopItem(string name, bool purchasedItem)
        {
            if (purchasedItem)
            {
                Console.WriteLine($"you have purchased {name}");
            }
            else
            {
                Console.WriteLine("You lack coins, return when you can afford something");
            }
        }
    }
}
