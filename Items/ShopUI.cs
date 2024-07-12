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
    }
}
