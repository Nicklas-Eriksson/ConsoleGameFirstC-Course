using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Items
{
    public class Item : IItem
    {
        private string name;
        private int goldCost;
        private int goldIfSold;
        private int itemLevel;


        public string Name { get => name; set => name = value; }
        public int GoldCost { get => goldCost; set => goldCost = value; }
        public int GoldIfSold { get => goldIfSold; set => goldIfSold = value; }
        public int ItemLevel { get => itemLevel; set => itemLevel = value; }

        public static List<IItem> UselessStuff { get => UselessStuff; set => UselessStuff = value; }
        public static List<IItem> InventoryList { get => InventoryList; set => InventoryList = value; } //Bug?
        public static List<string> stuffNames = new List<string> { "Stick", "Eye-ball", "Rope", "Funky mushroom", "Hairy spiderleg", "Broom handle", "Small sticky bone", "Chain", "Mysterious still burning coal", "Lost puppy", "Rock", "Small rock", "Pebble", "Potato", "Scalp", "Glowing emerald", "Candle", "Oozing slime", "Inner ear bone", "Non descript tail", "Ancient book", "Small cow bell", "Horse shoe", "Cursed necklace", "Iron rod", "Stewing stew", "Extremely old bread", "Assless Chaps", "Fork", "Spoon", "Chicken", "Sad chicken", "Delirious mouse", "Knitted hat", "Tea pot", "Nose ring" };


        //Generates a useless iteam, can be sold to a blue eyed salesman perhaps
        public static Item StuffGenerator()
        {
            Random rnd = new Random();
            int rndNr = rnd.Next(0, stuffNames.Count);

            int rndNr2 = rnd.Next(5, 200);
            Item item = new Item() {
                name = stuffNames[rndNr],
                goldCost = 0,
                goldIfSold = rndNr2
            };

            return item;
        }
    }
}
