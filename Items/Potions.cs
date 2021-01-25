using Labb3.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Items
{
    [Serializable]

    public class Potions : AbstractItem
    {
        public static Potions pot = new Potions();
        public static List<Potions> itemList = new List<Potions>();
                
        private int bonus;               
        public int Bonus { get => bonus; set => bonus = value; }

        public static void Instantiate()
        {
            Potions minorHealing = new Potions()
            {
                Name = "Minor healing potion",
                GoldCost = 50,
                GoldIfSold = 25,
                ItemLevel = 1,
                Bonus = 50
            };
            Potions greaterHealing = new Potions()
            {
                Name = "Greater healing potion",
                GoldCost = 150,
                ItemLevel = 2,
                GoldIfSold = 75,
                Bonus = 150
            };
            Potions majorHealing = new Potions()
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
