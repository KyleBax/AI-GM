using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Items
{
    internal class Loot
    {
        Item item = new Item();
        public Item GetRandomItem()
        {
            item.Rarity = GetRandomEnumValue<Rarity>();
            item.Type = GetRandomEnumValue<ItemType>();
            item.Name = GetRandomName();
            item.Cost = GetRandomCost();
            item.Weight = GetRandomWeight();
            item.ExtraDice = GetRandomExtraDice();
            return item;
        }

        private int GetRandomExtraDice()
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
        private int GetRandomWeight()
        {
            return 0;
        }

        private int GetRandomCost()
        {
            int cost;
            switch (item.Rarity)
            {
                case Rarity.Common:
                    cost = Dice.DiceRoll(10);
                    break;
                case Rarity.Uncommon:
                    cost = Dice.DiceRoll(15)+10;
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
        //TODO add name generation
        private string GetRandomName()
        {
            switch (item.Type)
            {
                case ItemType.Armour:
                    break;
                case ItemType.Weapon:
                    break;
                case ItemType.Potion:
                    break;
            }

            return "broken item name";
        }

        public static T GetRandomEnumValue<T>() where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));
            int randomNum = Dice.DiceRoll(values.Length);
            return (T)values.GetValue(randomNum);
        }
    }
}
