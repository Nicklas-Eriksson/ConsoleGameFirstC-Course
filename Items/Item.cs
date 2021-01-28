using System;
using System.Collections.Generic;

namespace Labb3.Items
{
    [Serializable]
    public abstract class AbstractItem : IItem
    {
        private int goldCost;
        private int goldIfSold;

        public string Name { get; set; }
        public int GoldCost { get => goldCost; set => goldCost = value; }
        public int GoldIfSold { get => goldIfSold; set => goldIfSold = goldCost / 5; }
        public int ItemLevel { get; set; }
    }

    [Serializable]
    public class Item : AbstractItem
    {
        public static List<IItem> UselessStuff { get => UselessStuff; set => UselessStuff = value; }
        public static List<string> stuffNames = new List<string> { "Stick", "Eye-ball", "Rope", "Funky mushroom", "Hairy spider leg", "Broom handle", "Small sticky bone", "Chain", "Mysterious still burning coal", "Lost puppy", "Rock", "Small rock", "Pebble", "Potato", "Scalp", "Glowing emerald", "Candle", "Oozing slime", "Inner ear bone", "Nondescript tail", "Ancient book", "Small cow bell", "Horse shoe", "Cursed necklace", "Iron rod", "Stewing stew", "Extremely old bread", "Ass-less Chaps", "Fork", "Spoon", "Chicken", "Sad chicken", "Delirious mouse", "Knitted hat", "Tea pot", "Nose ring" };

        private static readonly List<IItem> InventoryList = new List<IItem>();

        public static void SetList(List<IItem> list)
        {
            Item.InventoryList.AddRange(list);
        }

        public static List<IItem> GetList()
        {
            return InventoryList;
        }

        //Generates a useless item, can be sold to a blue eyed salesman perhaps
        public static Item StuffGenerator()
        {
            var rnd = new Random();
            int rndName = rnd.Next(0, stuffNames.Count);
            int rndGold = rnd.Next(5, 200);

            Item item = new Item()
            {
                Name = stuffNames[rndName],
                GoldCost = rndGold,
                GoldIfSold = 0
            };

            return item;
        }
    }
}