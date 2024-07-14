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
        public static Character ShopMain(Character character)
        {
            int shopSaleIncrease = 2;
            Item selectedItem = new Item();
            List<Item> instock = new List<Item>();
            bool sell = ShopUI.EnterShop();
            if (sell)
            {
                int saleCost = 0;
                for (int i = 0; i < character.Inventory.Count; i++)
                {
                    saleCost += character.Inventory[i].Cost;
                }
                ShopUI.SoldItems(saleCost);
                character.Inventory.Clear();
                character.Coins += saleCost;
            }

            for (int i = 0; i < 5; i++)
            {
                instock.Add(Loot.GetRandomShopItem(i));
            }
            ShopUI.PrintShopItems(instock, shopSaleIncrease);

            bool gotCoin = CoinCheck(character.Coins);
            ShopUI.CoinCheck(character.Coins, gotCoin);
            if (gotCoin)
            {
                try
                {
                    int selection = UI.GetIntInput();

                    if (selection >= 1 && selection <= instock.Count)
                    {
                        selectedItem = instock[selection - 1];
                        bool purchasedItem = false;
                        if (character.Coins >= selectedItem.Cost * shopSaleIncrease)
                        {
                            character.Coins = character.Coins - selectedItem.Cost * shopSaleIncrease;
                            purchasedItem = true;
                            bool equipItem = LootUI.EquipItem(character, selectedItem);
                            if (equipItem)
                            {
                                switch (selectedItem.Type)
                                {
                                    case ItemType.Armour:
                                        character.Armour = selectedItem;
                                        break;
                                    case ItemType.Weapon:
                                        character.Weapon = selectedItem;
                                        break;
                                }
                            }
                            else
                            {
                                character.Inventory.Add(selectedItem);
                            }
                        }  
                        else
                        {
                            purchasedItem = false;
                        }
                        ShopUI.PurchaseShopItem(selectedItem.Name, purchasedItem);
                    }
                    else
                    {
                        ShopUI.InvalidSelection();

                    }
                }
                catch
                {
                    ShopUI.InvalidSelection();
                }
            }
            return character;
        }

        private static bool CoinCheck(int coins)
        {
            if(coins < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
