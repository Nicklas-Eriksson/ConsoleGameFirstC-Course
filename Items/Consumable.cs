using Labb3.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Items
{
    public class Consumable : IItem
    {
        public static Consumable pot = new Consumable();
        public static List<Consumable> itemList = new List<Consumable>();

        public string name { get => name; set => name = value; }
        public int goldCost { get => goldCost; set => goldCost = value; }
        public int itemLevel { get => itemLevel; set => itemLevel = value; }
        public int bonus { get => bonus; set => bonus = value; }


        public void Instantiate()
        {
            Consumable lesserHealing = new Consumable()
            {
                name = "Lesser Healing Potion",
                goldCost = 50,
                itemLevel = 1,
                bonus = 50
            };
            Consumable minorHealing = new Consumable()
            {
                name = "Minor Healing Potion",
                goldCost = 150,
                itemLevel = 2,
                bonus = 150
            };
            Consumable majorHealing = new Consumable()
            {
                name = "Major Healing Potion",
                goldCost = 400,
                itemLevel = 3,
                bonus = 400
            };

            itemList.Add(lesserHealing);
            itemList.Add(minorHealing);
            itemList.Add(majorHealing);

        }
    }
}
