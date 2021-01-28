using System;
using System.Collections.Generic;

namespace Labb3.Items
{
    [Serializable]
    public class Potions : AbstractItem
    {
        private int goldCost;

        public static Potions pot = new Potions();
        public static List<Potions> potionList = new List<Potions>();
        public int Bonus { get; set; }
        public int GoldCost { get => goldCost; set => goldCost = value; }

        private void PotionForge()
        {
            var minorHealing = new Potions()
            {
                Name = "Minor healing potion",
                GoldCost = 100,
                ItemLevel = 1,
                Bonus = 50
            };
            var greaterHealing = new Potions()
            {
                Name = "Greater healing potion",
                GoldCost = 200,
                ItemLevel = 2,
                Bonus = 150
            };
            var majorHealing = new Potions()
            {
                Name = "Major healing potion",
                GoldCost = 300,
                ItemLevel = 3,
                Bonus = 400
            };

            potionList.Add(minorHealing);
            potionList.Add(greaterHealing);
            potionList.Add(majorHealing);
        }
        public static void Instantiate()
        {
            pot.PotionForge();
        }
    }
}