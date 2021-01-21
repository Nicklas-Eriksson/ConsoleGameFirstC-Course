using Labb3.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Items
{
    [Serializable]

    public class Consumable : IItem
    {
        public static Consumable pot = new Consumable();
        public static List<Consumable> itemList = new List<Consumable>();

        private string name;
        private int goldCost;
        private int goldIfSold;
        private int itemLevel;
        private int bonus;

        public string Name { get => name; set => name = value; }
        public int GoldCost { get => goldCost; set => goldCost = value; }
        public int GoldIfSold { get => goldIfSold; set => goldIfSold = value; }
        public int ItemLevel { get => itemLevel; set => itemLevel = value; }
        public int Bonus { get => bonus; set => bonus = value; }

        public void Instantiate()
        {
            Consumable minorHealing = new Consumable()
            {
                Name = "Lesser Healing Potion",
                GoldCost = 50,
                ItemLevel = 1,
                Bonus = 50
            };
            Consumable greaterHealing = new Consumable()
            {
                Name = "Minor Healing Potion",
                GoldCost = 150,
                ItemLevel = 2,
                Bonus = 150
            };
            Consumable majorHealing = new Consumable()
            {
                Name = "Major Healing Potion",
                GoldCost = 400,
                ItemLevel = 3,
                Bonus = 400
            };

            itemList.Add(minorHealing);
            itemList.Add(greaterHealing);
            itemList.Add(majorHealing);

        }
    }
}
