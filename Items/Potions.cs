using System;
using System.Collections.Generic;

namespace Labb3.Items
{
    [Serializable]
    public class Potions : AbstractItem
    {
        public static Potions pot = new Potions();
        public static List<Potions> itemList = new List<Potions>();
        public int Bonus { get; set; }

        public static void Instantiate()
        {
            var minorHealing = new Potions()
            {
                Name = "Minor healing potion",
                GoldCost = 50,
                GoldIfSold = 25,
                ItemLevel = 1,
                Bonus = 50
            };
            var greaterHealing = new Potions()
            {
                Name = "Greater healing potion",
                GoldCost = 150,
                ItemLevel = 2,
                GoldIfSold = 75,
                Bonus = 150
            };
            var majorHealing = new Potions()
            {
                Name = "Major healing potion",
                GoldCost = 400,
                GoldIfSold = 200,
                ItemLevel = 3,
                Bonus = 400
            };

            itemList.Add(minorHealing);
            itemList.Add(greaterHealing);
            itemList.Add(majorHealing);
        }
    }
}